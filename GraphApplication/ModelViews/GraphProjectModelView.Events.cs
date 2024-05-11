using System.Windows;
using System.Windows.Input;

namespace GraphApplication.ModelViews
{
    public partial class GraphProjectModelView
    {
        public void OnEditorClicked(object sender, RoutedEventArgs e)
        {
            EditorState?.EditorClicked(sender, e);
        }

        public void OnEditorMouseMove(object sender, MouseEventArgs e)
        {
            EditorState?.EditorMouseMove(sender, e);
        }

        public void OnEditorMouseUp(object sender, MouseButtonEventArgs e)
        {
            EditorState?.EditorMouseUp(sender, e);
        }

        public void OnEditorMouseDown(object sender, MouseButtonEventArgs e)
        {
            EditorState?.EditorMouseDown(sender, e);
        }

        public void OnVertexClicked(object sender, RoutedEventArgs e)
        {
            EditorState?.VertexClicked(sender, e);
        }

        public void OnVertexMouseMove(object sender, MouseEventArgs e)
        {
            EditorState?.VertexMouseMove(sender, e);
        }

        public void OnVertexMouseUp(object sender, MouseButtonEventArgs e)
        {
            EditorState?.VertexMouseUp(sender, e);
        }

        public void OnVertexMouseDown(object sender, MouseButtonEventArgs e)
        {
            EditorState?.VertexMouseDown(sender, e);
        }

        public void OnEdgeClicked(object sender, RoutedEventArgs e)
        {
            EditorState?.EdgeClicked(sender, e);
        }

        public void OnEdgeMouseMove(object sender, MouseEventArgs e)
        {
            EditorState?.EdgeMouseMove(sender, e);
        }

        public void OnEdgeMouseUp(object sender, MouseButtonEventArgs e)
        {
            EditorState?.EdgeMouseUp(sender, e);
        }

        public void OnEdgeMouseDown(object sender, MouseButtonEventArgs e)
        {
            EditorState?.EdgeMouseDown(sender, e);
        }
    }
}
