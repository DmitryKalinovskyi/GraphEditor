﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Models.Graph
{
    [DataContract(IsReference = true)]
    public class UndirectedGraphModel : UndirectedGraphModel<VertexModel, EdgeModel> 
    {
        public UndirectedGraphModel() { }

        public UndirectedGraphModel(IEnumerable<VertexModel> vertices, IEnumerable<EdgeModel> edges) : base(vertices, edges) { }
    }

    //[DataContract(IsReference = true)]
    //public class UndirectedWeightedGraphModel : UndirectedGraphModel<VertexModel, WeightedEdgeModel<double>> { }

    [DataContract(IsReference = true)]
    public class UndirectedGraphModel<TVertex, TEdge> : IGraphModel<TVertex, TEdge>
        where TVertex : VertexModel
        where TEdge : EdgeModel
    {
        public event EventHandler<TVertex>? OnVertexAdded;
        public event EventHandler<TEdge>? OnEdgeAdded;
        public event EventHandler<TVertex>? OnVertexRemoved;
        public event EventHandler<TEdge>? OnEdgeRemoved;

        [DataMember]
        private HashSet<TVertex> _vertices;
        
        [DataMember]
        private Dictionary<(TVertex, TVertex), TEdge> _edgeBinding;
        
        [DataMember]
        private Dictionary<TVertex, HashSet<TVertex>> _neighbors;

        public UndirectedGraphModel()
        {
            _vertices = new();
            _edgeBinding = new();
            _neighbors = new();
        }

        public UndirectedGraphModel(IEnumerable<TVertex> vertices, IEnumerable<TEdge> edges)
        {
            _edgeBinding = new();
            _neighbors = new();
            _vertices = new();

            foreach (var vertex in vertices) AddVertex(vertex);
            foreach (var edge in edges) BindEdge(edge);
        }

        private void BindEdge(TEdge edge)
        {
            if (IsConnectionBetween((TVertex)edge.Start, (TVertex)edge.End))
                throw new InvalidOperationException("Vertices already connected, there are not multigraph supporting.");

            _neighbors[(TVertex)edge.Start].Add((TVertex)edge.End);
            _neighbors[(TVertex)edge.End].Add((TVertex)edge.Start);
            _edgeBinding[((TVertex)edge.Start, (TVertex)edge.End)] = edge;
            _edgeBinding[((TVertex)edge.End, (TVertex)edge.Start)] = edge;
        }

        private void UnbindEdge(TEdge edge)
        {
            _neighbors[(TVertex)edge.Start].Remove((TVertex)edge.End);
            _neighbors[(TVertex)edge.End].Remove((TVertex)edge.Start);

            _edgeBinding.Remove(((TVertex)edge.Start, (TVertex)edge.End));
            _edgeBinding.Remove(((TVertex)edge.End, (TVertex)edge.Start));
        }

        public void AddEdge(TEdge edge)
        {
            if (edge.Start == null || edge.End == null)
                throw new ArgumentException("You can't add edge, that have start or end vertex null.");

            //_edges.Add(edge);
            BindEdge(edge);
            OnEdgeAdded?.Invoke(this, edge);
        }

        public void AddVertex(TVertex vertex)
        {
            _vertices.Add(vertex);
            _neighbors[vertex] = new();
            OnVertexAdded?.Invoke(this, vertex);
        }

        public TEdge? GetEdgeBetween(TVertex source, TVertex destination)
        {
            var key = (source, destination);
            return _edgeBinding.ContainsKey(key) ? _edgeBinding[key] : null;
        }

        public IEnumerable<TEdge> GetEdges()
        {
            // we have repeating edges
            return _edgeBinding.Values.Distinct();
        }

        public IEnumerable<TVertex> GetVertices()
        {
            return _vertices;
        }

        public bool IsConnectionBetween(TVertex source, TVertex destination)
        {
            return GetEdgeBetween(source, destination) != null;
        }

        public void RemoveEdge(TEdge edge)
        {
            UnbindEdge(edge);
            //_edges.Remove(edge);
            OnEdgeRemoved?.Invoke(this, edge);
        }

        public void RemoveVertex(TVertex vertex)
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

        public IEnumerable<TVertex> GetNeighbors(TVertex source)
        {
            if (_neighbors.ContainsKey(source) == false)
            {
                return Enumerable.Empty<TVertex>();
            }

            return _neighbors[source];
        }

        public IEnumerable<TEdge> GetEdges(TVertex source)
        {
            var neighbors = GetNeighbors(source);

            List<TEdge> edges = new();
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
