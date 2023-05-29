using GraphApplication.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.ModelView
{
    public class GraphModelView: NotifyModelView
    {

        private GraphModel _model;
        public GraphModel Model 
        {
            get {  return _model; }

            set
            {
                _model = value;

                //create all modelViews elements 
                Dictionary<VertexModel, VertexModelView> temp = new Dictionary<VertexModel, VertexModelView>();

                VertexModelViews = new ObservableCollection<VertexModelView>(
                    Model.Verticles.Select(vertexModel => {
                        VertexModelView modelView = new VertexModelView(vertexModel);
                        temp[vertexModel] = modelView;

                        return modelView;
                    }));

                EdgeModelViews = new ObservableCollection<EdgeModelView>(
                    Model.Edges.Select(edge =>
                    {
                        return new EdgeModelView(temp[edge.Start], temp[edge.End]);
                    }));

                VertexModelViews.CollectionChanged += (sender, e) =>
                {
                    if (e.NewItems != null)

                        foreach (VertexModelView vertexModelView in e.NewItems)
                            Model.Verticles.Add(vertexModelView.Model);

                    if (e.OldItems != null)
                        foreach (VertexModelView vertexModelView in e.OldItems)
                        {
                            //remove edge that associated with this verticle
                            EdgeModelViews = new ObservableCollection<EdgeModelView>(
                                EdgeModelViews.Where(edge => edge.Start != vertexModelView && edge.End != vertexModelView));

                            Model.Verticles.Remove(vertexModelView.Model);
                        }

                };
                EdgeModelViews.CollectionChanged += (sender, e) =>
                {
                    if (e.NewItems == null)
                        return;

                    foreach (EdgeModelView edgeModelView in e.NewItems)
                        Model.Edges.Add(edgeModelView.EdgeModel);

                    if (e.OldItems != null)
                        foreach (EdgeModelView edgeModelView in e.OldItems)
                            Model.Edges.Remove(edgeModelView.EdgeModel);

                };

                OnPropertyChanged(nameof(Model));
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
        public GraphModelView(GraphModel model)
        {
            Model = model;
        }

        public GraphModelView()
        {
            Model = new GraphModel();

            VertexModelViews = new ObservableCollection<VertexModelView>();
            EdgeModelViews = new ObservableCollection<EdgeModelView>();
        }
    }
}
