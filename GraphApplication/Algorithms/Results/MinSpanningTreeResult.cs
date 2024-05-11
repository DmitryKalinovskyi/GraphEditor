using GraphApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Algorithms.Results
{
    public class MinSpanningTreeResult
    {
        public readonly static MinSpanningTreeResult FailedToBuildTreeResult = new();

        public List<VertexModel> VertexModels { get; set; }

        public List<EdgeModel> EdgeModels { get; set; }

        public MinSpanningTreeResult(IEnumerable<VertexModel> vertexModels, IEnumerable<EdgeModel> edgeModels)
        {
            VertexModels = new(vertexModels);
            EdgeModels = new(edgeModels);
        }

        public MinSpanningTreeResult() : this(Enumerable.Empty<VertexModel>(), Enumerable.Empty<EdgeModel>()) { }
    }
}
