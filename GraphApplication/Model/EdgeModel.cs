using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Model
{
    public class EdgeModel: GraphObjectModel
    {
        public VertexModel Start { get; set; }
        public VertexModel End { get; set; }

        public EdgeModel() { }

        public EdgeModel(VertexModel from, VertexModel to)
        {
            Start = from;
            End = to;
        }
    }
}
