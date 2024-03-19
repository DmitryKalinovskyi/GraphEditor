using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Models.GraphRepresentations
{
    public class GraphModel_EdgeDictionary: IGraphModel
    {
        public Dictionary<(VertexModel, VertexModel), EdgeModel> EdgeDictionary { get; set; }

        public List<VertexModel> Verticles { get; set; }

        public GraphModel_EdgeDictionary() : this(new(), new()) { }

        public GraphModel_EdgeDictionary(Dictionary<(VertexModel, VertexModel), EdgeModel> edgeDictionary, List<VertexModel> verticles)
        {
            EdgeDictionary = edgeDictionary;
            Verticles = verticles;
        }

        public event EventHandler<VertexModel>? OnVertexAdded;
        public event EventHandler<EdgeModel>? OnEdgeAdded;
        public event EventHandler<VertexModel>? OnVertexRemoved;
        public event EventHandler<EdgeModel>? OnEdgeRemoved;

        public void AddVertex(VertexModel vertex)
        {
            Verticles.Add(vertex);
        }

        public void RemoveVertex(VertexModel vertex)
        {

        }

        public void AddEdge(EdgeModel edge)
        {
            throw new NotImplementedException();
        }

        public void RemoveEdge(EdgeModel edge)
        {
            EdgeDictionary.Remove((edge.Start, edge.End));
            EdgeDictionary.Remove((edge.End, edge.Start));

            OnEdgeRemoved?.Invoke(this, edge);
        }

        public bool IsConnectionBetween(VertexModel vertex1, VertexModel vertex2)
        {
            return GetEdgeBetween(vertex1, vertex2) != null;
        }

        public EdgeModel? GetEdgeBetween(VertexModel vertex1, VertexModel vertex2)
        {
            if(EdgeDictionary.ContainsKey((vertex1, vertex2)))
                return EdgeDictionary[(vertex1, vertex2)];

            return null;
        }
    }
}
