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

        //simulate click

        bool isClicked = false;

        public override void EditorDown(object sender, MouseEventArgs e)
        {
            //we get editor
            UIElement view = (UIElement)sender;

            isClicked = true;

            view.CaptureMouse();
        }

        public override void EditorUp(object sender, MouseEventArgs e)
        {
            if (isClicked == false) return;

            isClicked = false;



            //we get editor
            UIElement view = (UIElement)sender;

            Point p = e.GetPosition(view);

            VertexModelView vertexModelView = new VertexModelView(new VertexModel(p.X, p.Y, "Created"), _modelView);

            _modelView.VertexModelViews.Add(vertexModelView);

            view.ReleaseMouseCapture();

        }
    }
}
