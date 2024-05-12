using System.Runtime.Serialization;

namespace GraphApplication.Models
{

    [DataContract(IsReference = true)]
    [KnownType(typeof(WeightedEdgeModel<double>))]
    public abstract class EdgeModel
    {
        [DataMember]
        public VertexModel Start { get; set; }

        [DataMember]
        public VertexModel End { get; set; }

        public EdgeModel(VertexModel from, VertexModel to)
        {
            Start = from;
            End = to;
        }
    }
}
