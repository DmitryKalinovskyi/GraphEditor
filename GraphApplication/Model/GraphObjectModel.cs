using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Model
{
    public class GraphObjectModel
    {
        public double Left { get; set; }

        public double Top { get; set; }

        public GraphObjectModel()
        {
            Left = 0; Top = 0;
        }

        public GraphObjectModel(double left, double top)
        {
            Left = left; Top = top;
        }
    }
}
