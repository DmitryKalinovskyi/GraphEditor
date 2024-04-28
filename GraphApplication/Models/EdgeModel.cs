using System.Runtime.Serialization;

namespace GraphApplication.Models
{

    [DataContract(IsReference = true)]

    public class EdgeModel 
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
