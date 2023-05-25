using GraphApplication.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GraphApplication.ModelView.Extensions
{
    class GraphEditorSelectionMode : GraphEditorMode
    {
        public GraphEditorSelectionMode(GraphEditorModelView modelView) : base(modelView)
        {

        }

        public override void MouseDown(VertexView vertexModelView, MouseEventArgs e)
        {
        }

    }
}
