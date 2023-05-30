using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApplication.ModelView.GraphEditorExtensions.Modes
{
    public abstract class GraphEditorBuildingMode : GraphEditorMode
    {
        protected GraphEditorBuildingMode(GraphEditorModelView modelView) : base(modelView)
        {
        }
    }
}
