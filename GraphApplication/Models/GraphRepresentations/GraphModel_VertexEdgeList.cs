using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GraphApplication.Models.GraphRepresentations
{
    [DataContract(IsReference = true)]
    public class GraphModel_VertexEdgeList: IGraphModel
    {
        [DataMember]
        private List<VertexModel> _vertices;

        [DataMember]
        private List<EdgeModel> _edges;

        public event EventHandler<VertexModel>? OnVertexAdded;
        public event EventHandler<EdgeModel>? OnEdgeAdded;
        public event EventHandler<VertexModel>? OnVertexRemoved;
        public event EventHandler<EdgeModel>? OnEdgeRemoved;

        public List<VertexModel> Vertices => _vertices;

        public List<EdgeModel> Edges => _edges;

        /// <summary>
        /// Time complexity O(1)
        /// </summary>
        /// <param name="vertex"></param>
        public void AddVertex(VertexModel vertex)
        {
            _vertices.Add(vertex);
            OnVertexAdded?.Invoke(this, vertex);
        }

        /// <summary>
        /// Time complexity O(Vertices + Edges)
        /// </summary>
        /// <param name="vertex"></param>
        public void RemoveVertex(VertexModel vertex)
        {
            _vertices.Remove(vertex);
            ClearEdgesConnectedTo(vertex);
            OnVertexRemoved?.Invoke(this, vertex);
        }

        /// <summary>
        /// Time complexity O(1)
        /// </summary>
        /// <param name="edge"></param>
        public void AddEdge(EdgeModel edge)
        {
            _edges.Add(edge);
            OnEdgeAdded?.Invoke(this, edge);
        }

        /// <summary>
        /// Time complexity O(Edges)
        /// </summary>
        /// <param name="edge"></param>
        public void RemoveEdge(EdgeModel edge)
        {
            _edges.Remove(edge);
            OnEdgeRemoved?.Invoke(this, edge);
        }

        public void ClearEdgesConnectedTo(VertexModel vertex)
        {
            var edges = new List<EdgeModel>();
            foreach (var edge in Edges)
            {
                if (edge.Start != vertex && edge.End != vertex)
                    edges.Add(edge);
            }

            _edges = edges;
        }

        public void ClearUnusedEdges()
        {
            var edges = new List<EdgeModel>();
            foreach(var edge in Edges)
            {
                if(edge.Start != null && edge.End != null)
                    edges.Add(edge);
            }

            _edges = edges;
        }

        /// <summary>
        /// Time complexity O(Edges)
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <returns></returns>
        public bool IsConnectionBetween(VertexModel vertex1, VertexModel vertex2)
        {
            return GetEdgeBetween(vertex1, vertex2) != null;
        }

        /// <summary>
        /// Time complexity O(Edges)
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <returns></returns>
        public EdgeModel? GetEdgeBetween(VertexModel vertex1, VertexModel vertex2)
        {
            foreach(var edge in Edges)
            {
                if(edge.Start == vertex1 && edge.End == vertex2) return edge;
            }

            return null;
        }

        public IEnumerable<VertexModel> GetVertices()
        {
            return Vertices;
        }

        public IEnumerable<EdgeModel> GetEdges()
        {
            return Edges;
        }

        public GraphModel_VertexEdgeList(List<VertexModel> verticles, List<EdgeModel> edges)
        {
            _vertices = verticles;
            _edges = edges;
        }

        public GraphModel_VertexEdgeList() : this(new List<VertexModel>(), new List<EdgeModel>()) { }
    }
}
