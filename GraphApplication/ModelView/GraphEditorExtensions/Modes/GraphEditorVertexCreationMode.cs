using GraphApplication.Model;
using GraphApplication.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraphApplication.ModelView.GraphEditorExtensions
{
    class GraphEditorVertexCreationMode : GraphEditorMode
    {
        public GraphEditorVertexCreationMode(GraphEditorModelView modelView) : base(modelView)
        {

        }

        public override void EditorMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is IInputElement)
            {
                Point createPoint = Mouse.GetPosition((IInputElement)sender);

                VertexModelView vertexModelView = new VertexModelView(new VertexModel(createPoint.X, createPoint.Y, "Created"), _modelView);

                _modelView.VertexModelViews.Add(vertexModelView);

                Trace.WriteLine("Vertex created at point: " + createPoint.X + " " + createPoint.Y);
            }
        }
    }
}
