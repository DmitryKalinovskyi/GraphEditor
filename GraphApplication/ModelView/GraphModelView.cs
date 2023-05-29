using GraphApplication.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.ModelView
{
    public class GraphModelView: NotifyModelView
    {

        private GraphModel _model;

        Dictionary<VertexModel, VertexModelView> ModelViewAssociation = new Dictionary<VertexModel, VertexModelView>();

        public GraphModel Model 
        {
            get {  return _model; }

            set
            {
                _model = value;

                //create all modelViews elements 
                ModelViewAssociation = new Dictionary<VertexModel, VertexModelView>();


                VertexModelViews = new ObservableCollection<VertexModelView>(
                    Model.Verticles.Select(vertexModel => {
                        VertexModelView modelView = new VertexModelView(vertexModel);
                        ModelViewAssociation[vertexModel] = modelView;

                        return modelView;
                    }));

                EdgeModelViews = new ObservableCollection<EdgeModelView>(
                    Model.Edges.Select(edge =>
                    {
                        return new EdgeModelView(ModelViewAssociation[edge.Start], ModelViewAssociation[edge.End]);
                    }));

                VertexModelViews.CollectionChanged += OnVertexCollectionChanged;

                EdgeModelViews.CollectionChanged += OnEdgeCollectionChanged;

                OnPropertyChanged(nameof(Model));
            }
        }

        private void OnEdgeCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (EdgeModelView edgeModelView in e.NewItems)
                    Model.AddEdge(edgeModelView.EdgeModel);

            if (e.OldItems != null)
                foreach (EdgeModelView edgeModelView in e.OldItems)
                    Model.RemoveEdge(edgeModelView.EdgeModel);
        }

        private void OnVertexCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)

                foreach (VertexModelView vertexModelView in e.NewItems)
                {
                    Model.AddVertex(vertexModelView.Model);
                    ModelViewAssociation[vertexModelView.Model] = vertexModelView;
                }

            if (e.OldItems != null)
            {
                HashSet<VertexModelView> old = new HashSet<VertexModelView>(); 
                foreach (VertexModelView vertexModelView in e.OldItems)
                {
                    old.Add(vertexModelView);

                    Model.RemoveVertex(vertexModelView.Model);
                }

                //remove edge that associated with this verticles
                EdgeModelViews = new ObservableCollection<EdgeModelView>(
                    EdgeModelViews.Where(edge => old.Contains(edge.Start) == false && old.Contains(edge.End) == false));

                EdgeModelViews.CollectionChanged += OnEdgeCollectionChanged;
            }
        }

        private ObservableCollection<VertexModelView> _vertexModelViews;
        public ObservableCollection<VertexModelView> VertexModelViews
        {
            get { return _vertexModelViews; }
            set
            {
                _vertexModelViews = value;
                OnPropertyChanged(nameof(VertexModelViews));
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
        public GraphModelView(GraphModel model)
        {
            Model = model;
        }

        public GraphModelView()
        {
            Model = new GraphModel();
        }

        public int GetFreeIndex()
        {

            bool[] used = new bool[VertexModelViews.Count];

            foreach(var view in VertexModelViews)
            {
                int index = view.Model.Id;
                if (index >= used.Length)
                    continue;

                used[index] = true;
            }

            int i = 0;
            for (; i < used.Length; i++)
            {
                if (used[i] == false)
                    break;
            }

            return i;
        }
    }
}
