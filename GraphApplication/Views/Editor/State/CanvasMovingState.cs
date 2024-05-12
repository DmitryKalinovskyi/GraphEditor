using GraphApplication.ModelViews;
using GraphApplication.Views.Editor.State.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraphApplication.Views.Editor.State
{
    public class CanvasMovingState : EditorState
    {
        public CanvasMovingState(GraphProjectModelView modelView) : base(modelView) { }

        private bool isDragging = false;
        private Point dragPoint;

        private void UpdatePosition(Point delta)
        {
            _modelView.OffsetX += delta.X;
            _modelView.OffsetY += delta.Y;
        }

        public override void EditorMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Canvas canvas)
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
