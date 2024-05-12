using System.Windows;
using GraphApplication.ModelViews;
using GraphApplication.Views.Editor.State.Base;

namespace GraphApplication.Views.Editor.State
{
    public class VertexHideState : EditorState, IBuildingMode
    {
        public VertexHideState(GraphProjectModelView modelView) : base(modelView)
        {
        }

        public override void VertexClicked(object sender, RoutedEventArgs e)
        {
            VertexModelView vertexModelView = (sender as FrameworkElement).DataContext as VertexModelView;
            if (vertexModelView == null)
                return;

            vertexModelView.IsActive = !vertexModelView.IsActive;
            _modelView.SelectionManager.Diselect(vertexModelView);
        }
    }
}
