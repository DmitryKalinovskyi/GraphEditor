using System.Windows;
using System.Windows.Input;

namespace GraphApplication.ModelViews
{
    public partial class GraphProjectModelView
    {
        public void InitializeEvents()
        {

        }

        public void OnEditorClicked(object sender, RoutedEventArgs e)
        {
            EditorMode?.EditorClicked(sender, e);
        }

        public void OnEditorMouseMove(object sender, MouseEventArgs e)
        {
            EditorMode?.EditorMouseMove(sender, e);
        }

        public void OnEditorMouseUp(object sender, MouseButtonEventArgs e)
        {
            EditorMode?.EditorMouseUp(sender, e);
        }

        public void OnEditorMouseDown(object sender, MouseButtonEventArgs e)
        {
            EditorMode?.EditorMouseDown(sender, e);
        }

        public void OnVertexClicked(object sender, RoutedEventArgs e)
        {
            EditorMode?.VertexClicked(sender, e);
        }

        public void OnVertexMouseMove(object sender, MouseEventArgs e)
        {
            EditorMode?.VertexMouseMove(sender, e);
        }

        public void OnVertexMouseUp(object sender, MouseButtonEventArgs e)
        {
            EditorMode?.VertexMouseUp(sender, e);
        }

        public void OnVertexMouseDown(object sender, MouseButtonEventArgs e)
        {
            EditorMode?.VertexMouseDown(sender, e);
        }

        public void OnEdgeClicked(object sender, RoutedEventArgs e)
        {
            EditorMode?.EdgeClicked(sender, e);
        }

        public void OnEdgeMouseMove(object sender, MouseEventArgs e)
        {
            EditorMode?.EdgeMouseMove(sender, e);
        }

        public void OnEdgeMouseUp(object sender, MouseButtonEventArgs e)
        {
            EditorMode?.EdgeMouseUp(sender, e);
        }

        public void OnEdgeMouseDown(object sender, MouseButtonEventArgs e)
        {
            EditorMode?.EdgeMouseDown(sender, e);
        }
    }
}
