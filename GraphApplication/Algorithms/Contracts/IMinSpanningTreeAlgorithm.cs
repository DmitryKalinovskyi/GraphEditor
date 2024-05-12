using GraphApplication.Algorithms.Results;
using GraphApplication.Models;
using GraphApplication.Models.Graph;

namespace GraphApplication.Algorithms.Contracts
{
    public interface IMinSpanningTreeAlgorithm
    {
        public MinSpanningTreeResult FindMinSpanningTree(IGraphModel graph, VertexModel source, params object[] args);

        public MinSpanningTreeResult FindMinSpanningTreeForest(IGraphModel graph, params object[] args);
    }
}
