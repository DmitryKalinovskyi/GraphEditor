using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Models
{
    [DataContract(IsReference = true)]
    public class WeightedEdgeModel<TWeight>: EdgeModel
    {
        [DataMember]
        public TWeight? Weight { get; set; }

        public WeightedEdgeModel(VertexModel start, VertexModel end) : base(start, end) { }

        public WeightedEdgeModel(VertexModel start, VertexModel end, TWeight weight): base(start, end)
        {
            Weight = weight;
        }
    }
}
