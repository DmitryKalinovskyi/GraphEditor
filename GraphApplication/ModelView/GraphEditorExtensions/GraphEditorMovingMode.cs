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

namespace GraphApplication.ModelView.Extensions
{
    public class GraphEditorMovingMode : GraphEditorMode
    {
        public GraphEditorMovingMode(GraphEditorModelView modelView) : base(modelView)
        {

        }

        bool isDragging = false;
        Point dragPoint;

        void UpdatePosition(Point d, VertexView view)
        {
            (view.DataContext as VertexModelView).Top += d.Y;
            (view.DataContext as VertexModelView).Left += d.X;
        }
        public override void MouseDown(VertexView vertexView, MouseEventArgs e)
        {
            isDragging = true;
            Trace.WriteLine("Started dragging");
            dragPoint = e.GetPosition((UIElement)e.Source);

            ((UIElement)e.Source).CaptureMouse();
        }

        public override void MouseMove(VertexView vertexView, MouseEventArgs e)
        {
            if (isDragging == false) return;
            Trace.WriteLine("Moving");

            Point p = e.GetPosition((UIElement)e.Source);
            double dx = p.X - dragPoint.X;
            double dy = p.Y - dragPoint.Y;
            
            UpdatePosition(new Point(dx, dy), vertexView);
        }

        public override void MouseUp(VertexView vertexView, MouseEventArgs e)
        {
            Point p = e.GetPosition((UIElement)e.Source);
            double dx = p.X - dragPoint.X;
            double dy = p.Y - dragPoint.Y;

            UpdatePosition(new Point(dx, dy), vertexView);

            Trace.WriteLine("Ended dragging");

            isDragging = false;


            ((UIElement)e.Source).ReleaseMouseCapture();
        }


    }
}
