using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Models.GraphRepresentations
{
    public class GraphModel_EdgeDictionary
    {
        public Dictionary<(VertexModel, VertexModel), EdgeModel> EdgeDictionary { get; set; }

        public GraphModel_EdgeDictionary() : this(new()) { }

        public GraphModel_EdgeDictionary(Dictionary<(VertexModel, VertexModel), EdgeModel> edgeDictionary)
        {
            EdgeDictionary = edgeDictionary;
        }
    }
}
