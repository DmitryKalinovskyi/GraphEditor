using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphApplication.Models.GraphRepresentations
{
    /// <summary>
    /// This is hybrid representation of graph, all operation (except getting all vertices and edges, and except removing vertices) have O(1) Time complexity
    /// </summary>
    public class GraphModel_EdgeDictionaryVertexList: IGraphModel
    {
        public Dictionary<(VertexModel, VertexModel), EdgeModel> EdgeDictionary { get; set; }

        public List<VertexModel> Vertices { get; set; }

        public GraphModel_EdgeDictionaryVertexList() : this(new(), new()) { }

        public GraphModel_EdgeDictionaryVertexList(Dictionary<(VertexModel, VertexModel), EdgeModel> edgeDictionary, List<VertexModel> vertices)
        {
            EdgeDictionary = edgeDictionary;
            Vertices = vertices;
        }

        public event EventHandler<VertexModel>? OnVertexAdded;
        public event EventHandler<EdgeModel>? OnEdgeAdded;
        public event EventHandler<VertexModel>? OnVertexRemoved;
        public event EventHandler<EdgeModel>? OnEdgeRemoved;

        /// <summary>
        /// Time complexity O(1)
        /// </summary>
        /// <param name="vertex"></param>
        public void AddVertex(VertexModel vertex)
        {
            Vertices.Add(vertex);
            OnVertexAdded?.Invoke(this, vertex);
        }

        /// <summary>
        /// Time complexity O(Vertices)
        /// </summary>
        /// <param name="vertex"></param>
        public void RemoveVertex(VertexModel vertex)
        {
            Vertices.Remove(vertex);
            OnVertexRemoved?.Invoke(this, vertex);
        }

        /// <summary>
        /// Time complexity O(1)
        /// </summary>
        /// <param name="edge"></param>
        public void AddEdge(EdgeModel edge)
        {
            EdgeDictionary[(edge.Start, edge.End)] = edge;
            EdgeDictionary[(edge.End, edge.Start)] = edge;
            OnEdgeAdded?.Invoke(this, edge);
        }

        /// <summary>
        /// Time complexity O(1)
        /// </summary>
        /// <param name="edge"></param>
        public void RemoveEdge(EdgeModel edge)
        {
            EdgeDictionary.Remove((edge.Start, edge.End));
            EdgeDictionary.Remove((edge.End, edge.Start));

            OnEdgeRemoved?.Invoke(this, edge);
        }

        /// <summary>
        /// Time complexity O(1)
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <returns></returns>
        public bool IsConnectionBetween(VertexModel vertex1, VertexModel vertex2)
        {
            return GetEdgeBetween(vertex1, vertex2) != null;
        }


        /// <summary>
        /// Time comlexity O(1)
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <returns></returns>
        public EdgeModel? GetEdgeBetween(VertexModel vertex1, VertexModel vertex2)
        {
            if(EdgeDictionary.ContainsKey((vertex1, vertex2)))
                return EdgeDictionary[(vertex1, vertex2)];

            return null;
        }

        /// <summary>
        /// Time complexity O(Vertices)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<VertexModel> GetVertices()
        {
            // we can't return pointer to the actual vertices, then we just return copy.
            return Vertices.ToArray();
        }

        /// <summary>
        /// Time complexity O(Edges)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EdgeModel> GetEdges()
        {
            // why to hash set? because dict can contain copy values of the edges, hash set will make them unique.
            return EdgeDictionary.Values.ToHashSet();
        }
    }
}
