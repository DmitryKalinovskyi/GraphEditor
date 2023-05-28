using GraphApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.ModelView
{
    public class EdgeModelView: NotifyModelView
    {
        public readonly EdgeModel EdgeModel;

        public VertexModelView Start { get; private set; }
        public VertexModelView End { get; private set; }

        public EdgeModelView(VertexModelView start, VertexModelView end)
        { 
            EdgeModel = new EdgeModel(start.Model, end.Model);
            Start = start;
            End = end;
        }
    }
}
