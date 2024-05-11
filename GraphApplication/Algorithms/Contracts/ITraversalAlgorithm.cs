using GraphApplication.Algorithms.Results;
using GraphApplication.Models;
using GraphApplication.Models.Graph;

namespace GraphApplication.Algorithms.Contracts
{
    /// <summary>
    /// Interface used with algorithms, where you build route step by step, node by node, edge, by edge
    /// </summary>
    public interface ITraversalAlgorithm
    {
        public TraversalAlgorithmResult Traverse(IGraphModel graph, VertexModel source, params object[] args);
    }
}
