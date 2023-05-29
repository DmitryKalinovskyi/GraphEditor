using GraphApplication.CustomControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraphApplication.ModelView.GraphEditorExtensions.Modes
{
    public class GraphEditorCanvasMovingMode : GraphEditorMode
    {
        public GraphEditorCanvasMovingMode(GraphEditorModelView modelView) : base(modelView)
        {
        }

        bool isDragging = false;
        Point dragPoint;

        private void UpdatePosition(Point delta)
        {
            _modelView.OffsetX += delta.X;
            _modelView.OffsetY += delta.Y;
        }

        public override void EditorMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(sender is Canvas canvas)
            {
                isDragging = true;

                dragPoint = e.GetPosition(canvas);
                canvas.CaptureMouse();
            }
        }

        public override void EditorMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && sender is Canvas canvas)
            {
                _modelView.IsSaved = false;

                Point p = e.GetPosition(canvas);

                Point delta = new Point(p.X - dragPoint.X, p.Y - dragPoint.Y);
                UpdatePosition(delta);
                dragPoint = p;

            }
        }

        public override void EditorMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isDragging && sender is Canvas canvas)
            {
                _modelView.IsSaved = false;


                Point p = e.GetPosition(canvas);

                Point delta = new Point(p.X - dragPoint.X, p.Y - dragPoint.Y);

                UpdatePosition(delta);

                isDragging = false;
                canvas.ReleaseMouseCapture();
            }
        }
    }
}
