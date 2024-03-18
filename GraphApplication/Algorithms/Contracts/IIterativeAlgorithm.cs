using GraphApplication.Algorithms.Results;
using GraphApplication.Models.GraphRepresentations;

namespace GraphApplication.Algorithms.Contracts
{
    /// <summary>
    /// Interface used with algorithms, where you build route step by step, node by node, edge, by edge
    /// </summary>
    public interface IIterativeAlgorithm
    {
        public IterativeAlgorithmResult BuildRoute(GraphModel graph, params object[] args);
    }
}
