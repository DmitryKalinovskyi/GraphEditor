using GraphApplication.CustomControls;
using GraphApplication.ModelViews;
using GraphApplication.Views.Editor.State.Base;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace GraphApplication.Views.Editor.State
{
    public class VertexMovingState : EditorState, IBuildingMode
    {
        public VertexMovingState(GraphProjectModelView modelView) : base(modelView)
        {

        }

        bool isDragging = false;
        Point dragPoint;

        private void UpdatePosition(Point delta, VertexModelView modelView)
        {
            modelView.X += delta.X;
            modelView.Y += delta.Y;
        }


        public override void VertexMouseDown(object sender, MouseButtonEventArgs e)
        {

            if (sender is VertexButton vertexView && vertexView.DataContext is VertexModelView vertexModelView)
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
                vertexView.ReleaseMouseCapture();
            }
        }

        public override void OnModeSwitch()
        {
        }
    }
}
