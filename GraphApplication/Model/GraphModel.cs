using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Model
{
    public class GraphModel
    {
        public string Name { get; set; }

        public IEnumerable<GraphObjectModel> GraphObjects { get; set; }

        public GraphModel(string name, IEnumerable<GraphObjectModel> graphObjects)
        {
            Name = name;
            GraphObjects = graphObjects;
        }

        public GraphModel(string name)
        {
            Name = name;
            GraphObjects = new List<GraphObjectModel>();
        }
    }
}
