using GraphApplication.Model;
using GraphApplication.ModelView.GraphEditorExtensions;
using GraphApplication.Services.Commands;
using GraphApplication.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraphApplication.ModelView
{
    public partial class GraphEditorModelView: NotifyModelView
    {
        #region Commands
        private RelayCommand _createVertexCommand;

        public RelayCommand CreateVertexCommand
        {
            get
            {
                return _createVertexCommand ??
                     (_createVertexCommand = new RelayCommand(obj =>
                     {
                         try
                         {
                             //define args for our model
                             VertexModel vertex = new VertexModel();

                             VertexModelViews.Add(new VertexModelView(vertex, this));

                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show("Відбулася помилка виконання команди: " + ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                         }
                     }));
            }
        }
        private RelayCommand _createEdgeCommand;

        public RelayCommand CreateEdgeCommand
        {
            get
            {
                return _createEdgeCommand ??
                     (_createEdgeCommand = new RelayCommand(obj =>
                     {
                         try
                         {
                             //define args for our model



                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show("Відбулася помилка виконання команди: " + ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                         }
                     }));
            }
        }
        #endregion

        private GraphEditorModel _model;

        public IEnumerable<VertexModel> VertexObjects
        {
            get { return _model.VertexObjects; }
            set
            {
                _model.VertexObjects = value;
                OnPropertyChanged(nameof(_model.VertexObjects));
            }
        }

        public IEnumerable<EdgeModel> EdgeObjects
        {
            get { return _model.EdgeObjects; }
            set
            {
                _model.EdgeObjects = value;
                OnPropertyChanged(nameof(_model.EdgeObjects));
            }
        }

        private ObservableCollection<VertexModelView> _vertexModelViews;
        public ObservableCollection<VertexModelView> VertexModelViews
        {
            get { return _vertexModelViews; }
            set
            {
                _vertexModelViews = value;
                OnPropertyChanged(nameof(_vertexModelViews));
            }
        }
        private ObservableCollection<EdgeModelView> _edgeModelViews;
        public ObservableCollection<EdgeModelView> EdgeModelViews
        {
            get { return _edgeModelViews; }
            set
            {
                _edgeModelViews = value;
                OnPropertyChanged(nameof(EdgeModelViews));
            }
        }

        public string Name
        {
            get { return _model.Name; }
            set
            {
                _model.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public bool IsSaved
        {
            get { return _model.IsSaved; }
            set
            {
                _model.IsSaved = value;
                OnPropertyChanged(nameof(IsSaved));
            }
        }


        private double _scaleValue = 1;
        public double ScaleValue 
        {
            get { return _scaleValue; }
            set
            {
                _scaleValue = value;
                OnPropertyChanged(nameof(ScaleValue));
            }
        }

        private GraphEditorMode _currentEditorMode;

        public GraphEditorMode CurrentEditorMode
        {
            get { return _currentEditorMode; }
            set
            {
                _currentEditorMode = value;
                OnPropertyChanged(nameof(CurrentEditorMode));
            }
        }


        public GraphEditorModelView(GraphEditorModel model)
        {
            _model = model;

            CurrentEditorMode = new GraphEditorVertexCreationMode(this);

            //create all modelViews for elements
            VertexModelViews = new ObservableCollection<VertexModelView>(
                _model.VertexObjects.Select(vertexModel => new VertexModelView(vertexModel, this)));


            EdgeModelViews = new ObservableCollection<EdgeModelView>();

            //EdgeModelViews = new ObservableCollection<EdgeModelView>(
            //    _model.EdgeObjects.Select(edgeModel => new EdgeModelView(edgeModel)));
            InitializeEvents();
        }
    }
}
