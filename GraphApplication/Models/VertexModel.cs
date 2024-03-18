using System.Runtime.Serialization;

namespace GraphApplication.Models
{

    [DataContract(IsReference = true)]
    public class VertexModel : GraphObjectModel
    {
        [DataMember]
        public string Caption { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public double Left { get; set; }

        [DataMember]
        public double Top { get; set; }

        [DataMember]
        public bool IsActive { get; set; } = true;

        public VertexModel(int id)
        {
            Id = id;
            Caption = id.ToString();
        }
        public VertexModel(string caption, int id)
        {
            Caption = caption;
            Id = id;
        }
        public VertexModel(double left, double top, int id)
        {
            Caption = id.ToString();
            Id = id;
            Left = left;
            Top = top;
        }
        public VertexModel(double left, double top, string caption, int id)
        {
            Caption = caption;
            Left = left;
            Top = top;
        }

    }
}
