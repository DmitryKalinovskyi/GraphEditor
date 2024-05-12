using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace GraphApplication.Models.Graph
{
    //[DataContract(IsReference = true)]
    //public class UndirectedGraphModel : UndirectedGraphModel<VertexModel, EdgeModel> 
    //{
    //    public UndirectedGraphModel() { }

    //    public UndirectedGraphModel(IEnumerable<VertexModel> vertices, IEnumerable<EdgeModel> edges) : base(vertices, edges) { }
    //}

    //[DataContract(IsReference = true)]
    //public class UndirectedWeightedGraphModel : UndirectedGraphModel<VertexModel, WeightedEdgeModel<double>> { }

    [DataContract(IsReference = true)]
    public class UndirectedGraphModel : IGraphModel
    {
        public event EventHandler<VertexModel>? OnVertexAdded;
        public event EventHandler<EdgeModel>? OnEdgeAdded;
        public event EventHandler<VertexModel>? OnVertexRemoved;
        public event EventHandler<EdgeModel>? OnEdgeRemoved;

        [DataMember]
        private HashSet<VertexModel> _vertices;

        [DataMember]
        private Dictionary<(VertexModel, VertexModel), EdgeModel> _edgeBinding;

        [DataMember]
        private Dictionary<VertexModel, HashSet<VertexModel>> _neighbors;

        public UndirectedGraphModel()
        {
            _vertices = new();
            _edgeBinding = new();
            _neighbors = new();
        }

        public UndirectedGraphModel(IEnumerable<VertexModel> vertices, IEnumerable<EdgeModel> edges)
        {
            _edgeBinding = new();
            _neighbors = new();
            _vertices = new();

            foreach (var vertex in vertices) AddVertex(vertex);
            foreach (var edge in edges) BindEdge(edge);
        }

        private void BindEdge(EdgeModel edge)
        {
            if (IsConnectionBetween((VertexModel)edge.Start, (VertexModel)edge.End))
                throw new InvalidOperationException("Vertices already connected, there are not multigraph supporting.");

            _neighbors[(VertexModel)edge.Start].Add((VertexModel)edge.End);
            _neighbors[(VertexModel)edge.End].Add((VertexModel)edge.Start);
            _edgeBinding[((VertexModel)edge.Start, (VertexModel)edge.End)] = edge;
            _edgeBinding[((VertexModel)edge.End, (VertexModel)edge.Start)] = edge;
        }

        private void UnbindEdge(EdgeModel edge)
        {
            _neighbors[(VertexModel)edge.Start].Remove((VertexModel)edge.End);
            _neighbors[(VertexModel)edge.End].Remove((VertexModel)edge.Start);

            _edgeBinding.Remove(((VertexModel)edge.Start, (VertexModel)edge.End));
            _edgeBinding.Remove(((VertexModel)edge.End, (VertexModel)edge.Start));
        }

        public void AddEdge(EdgeModel edge)
        {
            if (edge.Start == null || edge.End == null)
                throw new ArgumentException("You can't add edge, that have start or end vertex null.");

            //_edges.Add(edge);
            BindEdge(edge);
            OnEdgeAdded?.Invoke(this, edge);
        }

        public void AddVertex(VertexModel vertex)
        {
            _vertices.Add(vertex);
            _neighbors[vertex] = new();
            OnVertexAdded?.Invoke(this, vertex);
        }

        public EdgeModel? GetEdgeBetween(VertexModel source, VertexModel destination)
        {
            var key = (source, destination);
            return _edgeBinding.ContainsKey(key) ? _edgeBinding[key] : null;
        }

        public IEnumerable<EdgeModel> GetEdges()
        {
            // we have repeating edges
            return _edgeBinding.Values.Distinct();
        }

        public IEnumerable<VertexModel> GetVertices()
        {
            return _vertices;
        }

        public bool IsConnectionBetween(VertexModel source, VertexModel destination)
        {
            return GetEdgeBetween(source, destination) != null;
        }

        public void RemoveEdge(EdgeModel edge)
        {
            UnbindEdge(edge);
            //_edges.Remove(edge);
            OnEdgeRemoved?.Invoke(this, edge);
        }

        public void RemoveVertex(VertexModel vertex)
        {
            // remove related edges
            //var edges = GetEdges(vertex);

            // remove each in deegre and out deegre vertex
            var edges = _edgeBinding.Values.Where(edge => edge.Start == vertex || edge.End == vertex);

            foreach (var edge in edges) RemoveEdge(edge);

            _vertices.Remove(vertex);
            _neighbors.Remove(vertex);
            OnVertexRemoved?.Invoke(this, vertex);
        }

        public int GetVerticesCount()
        {
            return _vertices.Count;
        }

        public int GetEdgesCount()
        {
            return _edgeBinding.Count / 2;
        }

        public IEnumerable<VertexModel> GetNeighbors(VertexModel source)
        {
            if (_neighbors.ContainsKey(source) == false)
            {
                return Enumerable.Empty<VertexModel>();
            }

            return _neighbors[source];
        }

        public IEnumerable<EdgeModel> GetEdges(VertexModel source)
        {
            var neighbors = GetNeighbors(source);

            List<EdgeModel> edges = new();
            // get edge between source and each neighbor
            foreach (var neighbor in neighbors)
            {
                var edge = GetEdgeBetween(source, neighbor);
                if (edge != null) edges.Add(edge);
            }

            return edges;
        }
    }
}
