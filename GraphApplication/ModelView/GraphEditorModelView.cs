using GraphApplication.Model;
using GraphApplication.ModelView.Extensions;
using GraphApplication.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraphApplication.ModelView
{
    public class GraphEditorModelView: NotifyModelView
    {
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


        private GraphEditorMode _currentEditorMode;

        public GraphEditorMode CurrentEditorMode
        {
            get { return _currentEditorMode; }
            set
            {
                _currentEditorMode = value;
                OnPropertyChanged(nameof(_currentEditorMode));
            }
        }


        public GraphEditorModelView(GraphEditorModel model)
        {
            _model = model;

            CurrentEditorMode = new GraphEditorMovingMode(this);

            //create all modelViews for elements
            VertexModelViews = new ObservableCollection<VertexModelView>(
                _model.VertexObjects.Select(vertexModel => new VertexModelView(vertexModel, this)));

            //subsribe
            foreach (var vertexModelView in VertexModelViews)
                VertexModelViewSubsribe(vertexModelView);

        }

        public void VertexModelViewSubsribe(VertexModelView vertexModelView)
        {
            vertexModelView.MouseDown += (sender, e) => CurrentEditorMode.MouseDown(sender as VertexView, e);
            vertexModelView.MouseMove += (sender, e) => CurrentEditorMode.MouseMove(sender as VertexView, e);
            vertexModelView.MouseUp += (sender, e) => CurrentEditorMode.MouseUp(sender as VertexView, e);
        }


    }
}
