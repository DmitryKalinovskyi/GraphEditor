using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Model
{

    [DataContract(IsReference = true)]

    public class EdgeModel: GraphObjectModel
    {
        [DataMember]
        public VertexModel Start { get; set; }

        [DataMember]
        public VertexModel End { get; set; }

        public EdgeModel() { }

        public EdgeModel(VertexModel from, VertexModel to)
        {
            Start = from;
            End = to;
        }
    }
}
