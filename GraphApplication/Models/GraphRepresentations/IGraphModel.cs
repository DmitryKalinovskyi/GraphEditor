namespace GraphApplication.Models.GraphRepresentations
{
    public interface IGraphModel
    {
        public void AddVertex(VertexModel vertex);
        public void RemoveVertex(VertexModel vertex);

        public void AddEdge(EdgeModel edge);
        public void RemoveEdge(EdgeModel edge);

        public bool IsConnectionBetween(VertexModel vertex1, VertexModel vertex2);
        public EdgeModel? GetEdgeBetween(VertexModel vertex1, VertexModel vertex2);
    }
}
