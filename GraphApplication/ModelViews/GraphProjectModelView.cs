using GraphApplication.Commands;
using GraphApplication.Commands.CommandList;
using GraphApplication.Models;
using GraphApplication.Views.Editor.State;
using GraphApplication.Views.Editor.State.Base;
using System;
using System.Collections.Generic;

namespace GraphApplication.ModelViews
{
    public partial class GraphProjectModelView : NotifyModelView
    {
        #region Commands
        public Command? StartAlgorithmCommand { get; set; }

        public Command? EndAlgorithmCommand { get; set; }

        public Command? ChangeEditorStateCommand { get; set; }
        #endregion

        // general data related to the project
        public GraphProjectModel Model { get; private set; }

        // graph data
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

        #region ProjectOptions

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

        public bool ShowEdgeLabels
        {
            get => Model.ShowEdgeLabels;
            set
            {
                Model.ShowEdgeLabels = value;
                OnPropertyChanged(nameof(ShowEdgeLabels));
            }
        }

        #endregion

        private EditorState _editorState;

        public EditorState EditorState
        {
            get { return _editorState; }
            set
            {
                if (_editorState != null)
                    _editorState.OnModeSwitch();

                _editorState = value;
                OnPropertyChanged(nameof(EditorState));
            }
        }

        public GraphProjectModelView(GraphProjectModel model, string name = "", bool isSaved = false)
        {
            Model = model;
            Name = name;
            IsSaved = isSaved;

            EditorState = new SelectionState(this);

            GraphModelView = new GraphModelView(model.GraphModel);
            SelectionManager = new();
            AnimationManager = new();

            ConfigureSavingDependency();
            InitializeCommands();
        }

        private void ConfigureSavingDependency()
        {
            // when we should mark that our project is unsaved?
            // when we edited our graph.
            GraphModelView.PropertyChanged += (sender, args) => IsSaved = false;

            // when we changed properties of our project.
            PropertyChanged += (sender, args) =>
            {
                var ignoredProperties = new List<string> { nameof(IsSaved), nameof(GraphNameFormat), nameof(Name) };

                if (ignoredProperties.Contains(args.PropertyName) == false)
                {
                    IsSaved = false;
                }
            };

        }

        private void InitializeCommands()
        {
            StartAlgorithmCommand = new StartAlgorithmCommand(this);
            EndAlgorithmCommand = new EndAlgorithmCommand(AnimationManager);
            ChangeEditorStateCommand = new ChangeEditorStateCommand(this);
        }
    }
}
