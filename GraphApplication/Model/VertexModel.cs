using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Model
{

    [DataContract(IsReference = true)]
    public class VertexModel: GraphObjectModel
    {
        [DataMember]
        public string Caption { get; set; }

        [DataMember]
        public double Left { get; set; }

        [DataMember]
        public double Top { get; set; }

        public VertexModel()
        {
            Caption = "";
        }

        public VertexModel(string caption)
        {
            Caption = caption;
        }

        public VertexModel(double left, double top, string caption) 
        {
            Caption = caption;
            Left = left;
            Top = top;
        }

    }
}
