using System.Runtime.Serialization;
using System.Windows;

namespace GraphApplication.Models
{

    [DataContract(IsReference = true)]
    public class VertexModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Caption { get; set; }

        [DataMember]
        public double X { get; set; }

        [DataMember]
        public double Y { get; set; }

        [DataMember]
        public bool IsActive { get; set; } = true;

        public VertexModel(int id)
        {
            Id = id;
            Caption = id.ToString();
        }

        public VertexModel(int id, string caption) : this(id)
        {
            Caption = caption;
        }

        public VertexModel(int id, Point position) : this(id)
        {
            X = position.X;
            Y = position.Y;
        }

        public VertexModel(int id, double x, double y) : this(id)
        {
            X = x;
            Y = y;
        }
    }
}
