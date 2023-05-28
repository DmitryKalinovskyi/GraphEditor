using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.Model
{
    public class GraphEditorModel
    {
        public List<VertexModel> VertexObjects { get; set; }
        public List<EdgeModel> EdgeObjects { get; set; }

        public GraphEditorModel(List<GraphObjectModel> graphObjects)
        {
            VertexObjects = graphObjects.Where(item => item is VertexModel).Cast<VertexModel>().ToList();
            EdgeObjects = graphObjects.Where(item => item is EdgeModel).Cast<EdgeModel>().ToList();
        }

        public GraphEditorModel()
        {
            VertexObjects = new List<VertexModel>();
            EdgeObjects = new List<EdgeModel>();
        }
    }
}
