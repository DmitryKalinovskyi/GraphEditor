using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Model
{
    [DataContract(IsReference = true)]
    public class GraphModel
    {
        [DataMember]
        public List<VertexModel> Verticles { get; set; }

        [DataMember]
        public List<EdgeModel> Edges { get; set; }

        public GraphModel(List<VertexModel> verticles, List<EdgeModel> edges)
        {
            Verticles = verticles;
            Edges = edges;
        }

        public GraphModel()
        {
            Verticles = new List<VertexModel>();
            Edges = new List<EdgeModel>();
        }
    }
}
