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

        public IList<VertexModel>? VertexModels { get; set; }

        public IList<EdgeModel>? EdgeModels { get; set; }

        public IterativeAlgorithmResult(IList<VertexModel>? vertexModels, IList<EdgeModel>? edgeModels)
        {
            VertexModels = vertexModels;
            EdgeModels = edgeModels;
        }

        public IterativeAlgorithmResult() { }
    }
}
