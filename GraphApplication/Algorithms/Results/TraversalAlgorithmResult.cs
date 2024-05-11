using GraphApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraphApplication.Algorithms.Results
{
    /// <summary>
    /// Contains information to display route step by step in the graph
    /// </summary>
    public class TraversalAlgorithmResult
    {
        public readonly static TraversalAlgorithmResult FailedToTraverseResult = new();

        public List<VertexModel> VertexModels { get; set; }

        public List<EdgeModel> EdgeModels { get; set; }

        public TraversalAlgorithmResult(IEnumerable<VertexModel> vertexModels, IEnumerable<EdgeModel> edgeModels)
        {
            VertexModels = new(vertexModels);
            EdgeModels = new(edgeModels);
        }

        public TraversalAlgorithmResult(): this(Enumerable.Empty<VertexModel>(), Enumerable.Empty<EdgeModel>()) { }
    }
}
