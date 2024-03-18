using GraphApplication.Model;
using GraphApplication.ModelView.GraphEditorExtensions;
using GraphApplication.ModelView.GraphEditorExtensions.Displaying;
using GraphApplication.ModelView.GraphEditorExtensions.Modes;
using GraphApplication.Services.Commands;
using GraphApplication.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace GraphApplication.ModelView
{
    public partial class GraphEditorModelView : NotifyModelView
    {
        #region Commands
        //private RelayCommand _createVertexCommand;

        //public RelayCommand CreateVertexCommand
        //{
        //    get
        //    {
        //        return _createVertexCommand ??
        //             (_createVertexCommand = new RelayCommand(obj =>
        //             {
        //                 try
        //                 {
        //                     //define args for our model
        //                     VertexModel vertex = new VertexModel();

        //                     VertexModelViews.Add(new VertexModelView(vertex, this));

        //                 }
        //                 catch (Exception ex)
        //                 {
        //                     MessageBox.Show("Відбулася помилка виконання команди: " + ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
        //                 }
        //             }));
        //    }
        //}
        //private RelayCommand _createEdgeCommand;

        //public RelayCommand CreateEdgeCommand
        //{
        //    get
        //    {
        //        return _createEdgeCommand ??
        //             (_createEdgeCommand = new RelayCommand(obj =>
        //             {
        //                 try
        //                 {
        //                     //define args for our model



        //                 }
        //                 catch (Exception ex)
        //                 {
        //                     MessageBox.Show("Відбулася помилка виконання команди: " + ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
        //                 }
        //             }));
        //    }
        //}
        private RelayCommand _implementAlgorithmCommand;

        public RelayCommand ImplementAlgorithmCommand
        {
            get
            {
                return _implementAlgorithmCommand ??
                    (_implementAlgorithmCommand = new RelayCommand(obj =>
                    {
                        if (CurrentEditorMode is IAlgorithmImplementer implementer)
                        {
                            bool result = implementer.ImplementAlgorithm();

                            //if (AnimationManager.Animation != null)
                            //{
                            //    MessageBox.Show("Немає обраної анімації алгоритма", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                            //    return;
                            //}
                            if(result)
                            AnimationManager.StartAnimation();
                        }
                        else
                        {
                            MessageBox.Show("Алгоритм для реалізації не обрано!", "Попередження",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                        }

                    }));
            }
        }

        private RelayCommand _endImplementationCommand;

        public RelayCommand EndImplementationCommand
        {
            get
            {
                return _endImplementationCommand ??
                    (_endImplementationCommand = new RelayCommand(obj =>
                    {
                        try
                        {

                            if (AnimationManager.IsAnimationActive == false)
                            {
                                MessageBox.Show("Немає обраної анімації алгоритма", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }

                            AnimationManager.StopAnimation();
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex);
                        }
                    }));
            }
        }

        #endregion


        public GraphEditorModel Model { get; private set; }

        public GraphModelView GraphModelView {get; private set;}

        public GraphEditorSelectionManager SelectionManager { get; private set; }

        public GraphEditorAnimationManager AnimationManager { get; private set; }
        

        private string _name;
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
            get{
                return Name + (IsSaved ? "": "*");
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
            get { return Math.Clamp(Model.ScaleValue, GraphEditorModel.MinScale, GraphEditorModel.MaxScale); }
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

        private GraphEditorMode _currentEditorMode;

        public GraphEditorMode CurrentEditorMode
        {
            get { return _currentEditorMode; }
            set
            {
                if (_currentEditorMode != null)
                    _currentEditorMode.OnModeSwitch();

                _currentEditorMode = value;
                OnPropertyChanged(nameof(CurrentEditorMode));
            }
        }

        public GraphEditorModelView(GraphEditorModel model, string name, bool isSaved = false)
        {
            Model = model;
            Name = name;
            IsSaved = isSaved;

            CurrentEditorMode = new GraphEditorSelectionMode(this);
            GraphModelView = new GraphModelView(Model.GraphModel);
            SelectionManager = new();
            AnimationManager = new();
            
            InitializeEvents();
        }
    }
}
