using GraphApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Algorithms.Results
{
    public class ShortestPathResult
    {
        public readonly static ShortestPathResult FailedToFindShortestPathResult = new();

        public List<VertexModel> VertexModels { get; set; }

        public List<EdgeModel> EdgeModels { get; set; }

        public ShortestPathResult(IEnumerable<VertexModel> vertexModels, IEnumerable<EdgeModel> edgeModels)
        {
            VertexModels = new(vertexModels);
            EdgeModels = new(edgeModels);
        }

        public ShortestPathResult() : this(Enumerable.Empty<VertexModel>(), Enumerable.Empty<EdgeModel>()) { }
    }
}
