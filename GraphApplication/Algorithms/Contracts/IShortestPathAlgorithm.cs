using GraphApplication.Algorithms.Results;
using GraphApplication.Models;
using GraphApplication.Models.Graph;

namespace GraphApplication.Algorithms.Contracts
{
    public interface IShortestPathAlgorithm
    {
        public ShortestPathResult FindShortestPath(IGraphModel graph, VertexModel source, VertexModel target, params object[] args);
    }
}
