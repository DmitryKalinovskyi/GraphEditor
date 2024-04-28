using GraphApplication.Commands;
using GraphApplication.Exceptions;
using GraphApplication.Models;
using GraphApplication.Models.Graph;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace GraphApplication.ModelViews
{
    /// <summary>
    /// Manages binding between graph model and view.
    /// </summary>
    public class GraphModelView: NotifyModelView
    {
        public int VertexCount { get => Model.GetVerticesCount(); }
        public int EdgeCount { get => Model.GetEdgesCount(); }

        #region Commands

        // here will be commands such remove vertex, edge, add vertex, edge, they will change model, and after model will change modelView

        private RelayCommand? _removeVertexCommand;

        public RelayCommand RemoveVertexCommand => _removeVertexCommand ??= new RelayCommand((parameter) =>
        {
            var vertexModelView = (VertexModelView?)parameter;

            if (vertexModelView == null)
                throw new ArgumentException(nameof(vertexModelView));

            Model.RemoveVertex(vertexModelView.Model);
        });

        private RelayCommand? _addVertexCommand;

        // this is demo-version of command, this is a question who should build the actual model, view, or modelView?
        public RelayCommand AddVertexCommand => _addVertexCommand ??= new RelayCommand((parameter) =>
        {
            var vertex = (VertexModel?)parameter;

            if (vertex == null)
                throw new ArgumentException(nameof(vertex));

            Model.AddVertex(vertex);
        });

        #endregion

        public IGraphModel<VertexModel, EdgeModel> Model { get; private set; }

        // use by definition standart graph type, defined in settings.
        //public GraphModelView() : this(new GraphModel_VertexEdgeList()) { }

        public GraphModelView(IGraphModel<VertexModel, EdgeModel> model)
        {
            Model = model;
            VertexModelViews = new();
            EdgeModelViews = new();
            _edgeBinding = new();
            _vertexBinding = new();

            AssignEvents();
            CreateModelViews();
        }

        private void AssignEvents()
        {
            // this private methods depends from graph model, when model changes, view model updates, then it notificate the view.

            Model.OnEdgeAdded += (sender, edge) => AddEdge(edge);
            Model.OnEdgeRemoved += (sender, edge) => RemoveEdge(edge);
            Model.OnVertexAdded += (sender, vertex) => AddVertex(vertex);
            Model.OnVertexRemoved += (sender, vertex) => RemoveVertex(vertex);
        }

        private void AddEdge(EdgeModel edge)
        {
            var start = GetVertexModelView_By_VertexModel(edge.Start);
            var end = GetVertexModelView_By_VertexModel(edge.End);

            var edgeModelView = new EdgeModelView(edge, start, end);
            // bind
            _edgeBinding[edge] = edgeModelView;

            EdgeModelViews.Add(edgeModelView);
        }

        private void RemoveEdge(EdgeModel edge)
        {
            var edgeModelView = GetEdgeModelView_By_EdgeModel(edge);

            // unbind
            _edgeBinding.Remove(edge);

            EdgeModelViews.Remove(edgeModelView);
        }

        private void AddVertex(VertexModel vertex)
        {
            var vertexModelView = new VertexModelView(vertex);

            // bind
            _vertexBinding[vertex] = vertexModelView;

            VertexModelViews.Add(vertexModelView);
        }

        private void RemoveVertex(VertexModel vertex)
        {
            var vertexModelView = GetVertexModelView_By_VertexModel(vertex);

            // unbind
            _vertexBinding.Remove(vertex);

            VertexModelViews.Remove(vertexModelView);
        }

        private void CreateModelViews()
        {
            foreach (var vertex in Model.GetVertices())
                AddVertex(vertex);

            foreach (var edge in Model.GetEdges())
                AddEdge(edge);
        }

        public ObservableCollection<VertexModelView> VertexModelViews { get; private set; }
        public ObservableCollection<EdgeModelView> EdgeModelViews { get; private set; }

        private Dictionary<EdgeModel, EdgeModelView> _edgeBinding;
        private Dictionary<VertexModel, VertexModelView> _vertexBinding;

        public EdgeModelView GetEdgeModelView_By_EdgeModel(EdgeModel edgeModel)
        {
            if (_edgeBinding.ContainsKey(edgeModel))
                return _edgeBinding[edgeModel];

            throw new UnbindedModelViewException("EdgeModel don't have edgeModelView");
        }

        public VertexModelView GetVertexModelView_By_VertexModel(VertexModel vertexModel)
        {
            if (_vertexBinding.ContainsKey(vertexModel))
                return _vertexBinding[vertexModel];

            throw new UnbindedModelViewException("VertexModel don't have vertexModelView");
        }

        public List<EdgeModelView> GetEdgeModelViews_By_EdgeModels(IEnumerable<EdgeModel> models)
        {
            List<EdgeModelView> edgeModelViews = new();

            foreach (var model in models)
            {
                edgeModelViews.Add(GetEdgeModelView_By_EdgeModel(model));
            }

            return edgeModelViews;
        }

        public List<VertexModelView> GetVertexModelViews_By_VertexModels(IEnumerable<VertexModel> models)
        {
            List<VertexModelView> vertexModelViews = new();

            foreach (var model in models)
            {
                vertexModelViews.Add(GetVertexModelView_By_VertexModel(model));
            }

            return vertexModelViews;
        }

        // TODO: add methods to create edge between two verticles, add verticle
        // when edge or vertex is added view should be updated
        // better to implement comamnds, this allow client to manage command history if needed.

        // TODO: add methods to remove verticle and edges
        // when removing verticles you should remove edge that connected to verticle also.
        // you can add warning when removing verticle that have connected edges.
        // this warning can be offed in settings.

        // Sounds challenging with c# oop ;?

        // problems:

        // #1
        // we have graph model, graph model contains edgeModels, and vertexModels,
        // and you need to create ModelViews for each model, to keep mvvm interaction.

        // how we can get modelView based by model?

        // - list searching (too slow)
        // - using hashing (binding model to the modelView)
        // - assign special id, and use special service :O

        public int GetFreeIndex()
        {

            bool[] used = new bool[VertexModelViews.Count];

            foreach (var view in VertexModelViews)
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
