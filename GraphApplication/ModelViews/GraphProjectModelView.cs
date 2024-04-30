using GraphApplication.Commands;
using GraphApplication.Commands.CommandList;
using GraphApplication.Models;
using GraphApplication.Models.Graph;
using GraphApplication.ModelViews.GraphEditorExtensions;
using GraphApplication.ModelViews.GraphEditorExtensions.Modes;
using System;
using System.Diagnostics;
using System.Windows;

namespace GraphApplication.ModelViews
{
    public partial class GraphProjectModelView : NotifyModelView
    {
        #region Commands
        public Command? StartAlgorithmCommand { get; set; }

        public Command? EndAlgorithmCommand { get; set; }

        public Command? ChangeEditorModeCommand { get; set; } 
        #endregion

        public GraphProjectModel Model { get; private set; }

        public GraphModelView GraphModelView { get; private set; }

        public GraphEditorSelectionManager SelectionManager { get; private set; }

        public GraphEditorAnimationManager AnimationManager { get; private set; }

        private string _name = "";
        private bool _isSaved;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(GraphNameFormat));
            }
        }

        public bool IsSaved
        {
            get { return _isSaved; }
            set
            {
                _isSaved = value;
                OnPropertyChanged(nameof(IsSaved));
                OnPropertyChanged(nameof(GraphNameFormat));

            }
        }

        public string GraphNameFormat
        {
            get
            {
                return Name + (IsSaved ? "" : "*");
            }
        }

        public double OffsetX
        {
            get { return Model.OffsetX; }
            set
            {
                Model.OffsetX = value;
                OnPropertyChanged(nameof(OffsetX));
            }
        }

        public double OffsetY
        {
            get { return Model.OffsetY; }
            set
            {
                Model.OffsetY = value;
                OnPropertyChanged(nameof(OffsetY));
            }
        }

        public double ScaleValue
        {
            get { return Math.Clamp(Model.ScaleValue, GraphProjectModel.MinScale, GraphProjectModel.MaxScale); }
            set
            {
                Model.ScaleValue = value;
                OnPropertyChanged(nameof(ScaleValue));
            }
        }

        public double CachingScale
        {
            get { return Math.Clamp(Model.CachingScale, 0.05, 1); }
            set
            {
                Model.CachingScale = value;
                OnPropertyChanged(nameof(CachingScale));
            }
        }

        public double ActiveStrokeThickness
        {
            get => Model.ActiveStrokeThickness;
            set
            {
                Model.ActiveStrokeThickness = value;
                OnPropertyChanged(nameof(ActiveStrokeThickness));
            }
        }

        public double DefaultStrokeThickness
        {
            get => Model.DefaultStrokeThickness;
            set
            {
                Model.DefaultStrokeThickness = value;
                OnPropertyChanged(nameof(DefaultStrokeThickness));
            }
        }

        private GraphEditorMode _editorMode;

        public GraphEditorMode EditorMode
        {
            get { return _editorMode; }
            set
            {
                if (_editorMode != null)
                    _editorMode.OnModeSwitch();

                _editorMode = value;
                OnPropertyChanged(nameof(EditorMode));
            }
        }

        public GraphProjectModelView(GraphProjectModel model, string name, bool isSaved = false)
        {
            if (model.GraphModel == null)
                throw new ArgumentNullException(nameof(model.GraphModel));

            Model = model;
            Name = name;
            IsSaved = isSaved;

            EditorMode = new GraphEditorSelectionMode(this);
            
            GraphModelView = new GraphModelView(model.GraphModel);
            SelectionManager = new();
            AnimationManager = new();

            PropertyChanged += (sender, args) => {
                if(args.PropertyName != nameof(IsSaved) && args.PropertyName != nameof(GraphNameFormat))
                    IsSaved = false;
                };

            GraphModelView.PropertyChanged += (sender, args) => IsSaved = false;


            InitializeCommands();
            InitializeEvents();
        }

        private void InitializeCommands()
        {
            StartAlgorithmCommand = new StartAlgorithmCommand(this);
            EndAlgorithmCommand = new EndAlgorithmCommand(AnimationManager);
            ChangeEditorModeCommand = new ChangeEditorModeCommand(this);
        }
    }
}
