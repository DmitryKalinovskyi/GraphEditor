using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace GraphApplication.ModelViews.GraphEditorExtensions.Modes
{
    public class GraphEditorRemovingMode : GraphEditorMode, IBuildingMode
    {
        public GraphEditorRemovingMode(GraphEditorModelView modelView) : base(modelView)
        {
        }



        public override void EdgeMouseDown(object sender, MouseButtonEventArgs e)
        {
            //get clicked edge
            Trace.WriteLine("Edge removing..");

            EdgeModelView edgeModelView = (EdgeModelView)(sender as FrameworkElement).DataContext;

            if (edgeModelView != null)
            {
                _modelView.GraphModelView.EdgeModelViews.Remove(edgeModelView);
            }
            else
            {
                Trace.WriteLine("Edge does not removed");
            }

        }

        public override void OnModeSwitch()
        {
        }

        public override void VertexClicked(object sender, RoutedEventArgs e)
        {
            VertexModelView vertexModleView = (VertexModelView)(sender as FrameworkElement).DataContext;

            _modelView.GraphModelView.VertexModelViews.Remove(vertexModleView);
        }

    }
}
