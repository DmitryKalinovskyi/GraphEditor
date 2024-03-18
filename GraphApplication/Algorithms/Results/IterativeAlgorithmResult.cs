using GraphApplication.Models;
using System.Collections.Generic;

namespace GraphApplication.Algorithms.Results
{
    /// <summary>
    /// Contains information to display route step by step in the graph
    /// </summary>
    public class IterativeAlgorithmResult
    {
        public static IterativeAlgorithmResult FailedToBuildRouteResult = new(null, null);

        public IEnumerable<VertexModel>? VertexModels { get; set; }

        public IEnumerable<EdgeModel>? EdgeModels { get; set; }

        public IterativeAlgorithmResult(IEnumerable<VertexModel>? vertexModels, IEnumerable<EdgeModel>? edgeModels)
        {
            VertexModels = vertexModels;
            EdgeModels = edgeModels;
        }

        public IterativeAlgorithmResult() { }
    }
}
