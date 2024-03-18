using System.Collections.Generic;

namespace GraphApplication.Models.GraphRepresentations
{
    public class GraphModel_AdjancencyDictionary
    {
        public Dictionary<VertexModel, List<(EdgeModel, VertexModel)>> AdjencencyDictionary { get; set; }

        public GraphModel_AdjancencyDictionary() : this(new()) { }

        public GraphModel_AdjancencyDictionary(Dictionary<VertexModel, List<(EdgeModel, VertexModel)>> adjencencyDictionary)
        {
            AdjencencyDictionary = adjencencyDictionary;
        }
    }
}
