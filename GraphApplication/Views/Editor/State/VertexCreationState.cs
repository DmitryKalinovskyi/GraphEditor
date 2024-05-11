using GraphApplication.Models;
using GraphApplication.ModelViews;
using GraphApplication.Views.Editor.State.Base;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace GraphApplication.Views.Editor.State
{
    class VertexCreationState : EditorState, IBuildingMode
    {
        public VertexCreationState(GraphProjectModelView modelView) : base(modelView)
        {
            _modelView.SelectionManager.DiselectAll();
        }

        public override void EditorMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is IInputElement)
            {
                _modelView.IsSaved = false;

                Point createPoint = Mouse.GetPosition((IInputElement)sender);

                //gap position into canvas
                createPoint.X -= _modelView.OffsetX;
                createPoint.Y -= _modelView.OffsetY;
                createPoint.X /= _modelView.ScaleValue;
                createPoint.Y /= _modelView.ScaleValue;

                var vertexModel = new VertexModel(_modelView.GraphModelView.GetFreeIndex(), createPoint.X, createPoint.Y);

                _modelView.GraphModelView.AddVertexCommand.Execute(vertexModel);

                Trace.WriteLine("Vertex created at point: " + createPoint.X + " " + createPoint.Y);
            }
        }

        public override void OnModeSwitch()
        {
        }
    }
}
