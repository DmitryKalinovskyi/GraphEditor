using System;
using System.Collections.Generic;

namespace GraphApplication.Models.GraphRepresentations
{
    public interface IGraphModel
    {
        // Methods should notify about each event.
        public void AddVertex(VertexModel vertex);
        public void RemoveVertex(VertexModel vertex);

        public void AddEdge(EdgeModel edge);
        public void RemoveEdge(EdgeModel edge);

        public bool IsConnectionBetween(VertexModel vertex1, VertexModel vertex2);
        public EdgeModel? GetEdgeBetween(VertexModel vertex1, VertexModel vertex2);

        public IEnumerable<VertexModel> GetVertices();
        public IEnumerable<EdgeModel> GetEdges();

        // using events we can go from idea, where it the same time store all representations in one class, to 
        // idea implement another class, that can handle changes of the graph, and upbuild own version 
        public event EventHandler<VertexModel>? OnVertexAdded;
        public event EventHandler<EdgeModel>? OnEdgeAdded;

        public event EventHandler<VertexModel>? OnVertexRemoved;
        public event EventHandler<EdgeModel>? OnEdgeRemoved;
    }
}
