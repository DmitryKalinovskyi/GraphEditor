using GraphApplication.CustomControls;
using GraphApplication.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraphApplication.ModelView.GraphEditorExtensions.Modes
{
    public class GraphEditorMovingMode : GraphEditorBuildingMode
    {
        public GraphEditorMovingMode(GraphEditorModelView modelView) : base(modelView)
        {

        }

        bool isDragging = false;
        Point dragPoint;

        private void UpdatePosition(Point delta, VertexModelView modelView)
        {
            modelView.Top += delta.Y;
            modelView.Left += delta.X;
        }


        public override void VertexMouseDown(object sender, MouseButtonEventArgs e)
        {

            Trace.WriteLine("Draggion start");
            if(sender is VertexButton vertexView && vertexView.DataContext is VertexModelView vertexModelView)
            {

                isDragging = true;
                vertexView.CaptureMouse();

                dragPoint = e.GetPosition(vertexView);
                vertexModelView.IsSelected = true;
            }
        }

        public override void VertexMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging == false) return;

            if (sender is VertexButton vertexView && vertexView.DataContext is VertexModelView vertexModelView)
            {
                _modelView.IsSaved = false;

                Point p = e.GetPosition(vertexView);

                vertexModelView.IsSelected = true;
                Point delta = new Point(p.X - dragPoint.X, p.Y - dragPoint.Y);

                UpdatePosition(delta, vertexModelView);
            }
        }

        public override void VertexMouseUp(object sender, MouseButtonEventArgs e)
        {
            Trace.WriteLine("Draggion end");
            if (isDragging == false) return;

            if (sender is VertexButton vertexView && vertexView.DataContext is VertexModelView vertexModelView)
            {
                _modelView.IsSaved = false;

                Point p = e.GetPosition(vertexView);

                vertexModelView.IsSelected = true;
                Point delta = new Point(p.X - dragPoint.X, p.Y - dragPoint.Y);

                UpdatePosition(delta, vertexModelView);


                isDragging = false;
                vertexModelView.IsSelected = false;
                (vertexView).ReleaseMouseCapture();
            }
        }

        public override void OnModeSwitch()
        {
        }
    }
}
