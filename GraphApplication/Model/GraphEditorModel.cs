using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Model
{
    public class GraphEditorModel
    {
        public string Name { get; set; }

        public IEnumerable<VertexModel> VertexObjects { get; set; }
       // public IEnumerable<VertexModel> VertexObjects { get; set; }

        public bool IsSaved { get; set; } = false;

        public GraphEditorModel(string name, IEnumerable<GraphObjectModel> graphObjects)
        {
            Name = name;

            VertexObjects = graphObjects.Where(item => item is VertexModel).Cast<VertexModel>().ToList();
        }

        public GraphEditorModel(string name)
        {
            Name = name;
            VertexObjects = new List<VertexModel>();
        }
    }
}
