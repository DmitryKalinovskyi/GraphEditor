using System.Windows;

namespace GraphApplication.ModelViews.GraphEditorExtensions.Modes
{
    public class GraphEditorHideMode : GraphEditorMode, IBuildingMode
    {
        public GraphEditorHideMode(GraphProjectModelView modelView) : base(modelView)
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

        public override void OnModeSwitch()
        {
        }
    }
}
