using System.Windows;
using System.Windows.Input;

namespace GraphApplication.ModelView.GraphEditorExtensions
{
    public abstract class GraphEditorMode
    {

        protected readonly GraphEditorModelView _modelView;
        public GraphEditorMode(GraphEditorModelView modelView)
        {
            _modelView = modelView;
        }

        public virtual void OnModeSwitch() { }

        public virtual void EditorMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic for EditorMouseDown event handling
        }

        public virtual void EditorMouseMove(object sender, MouseEventArgs e)
        {
            // Implement your logic for EditorMouseMove event handling
        }

        public virtual void EditorMouseUp(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic for EditorMouseUp event handling
        }

        public virtual void EditorPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic for EditorPreviewMouseDown event handling
        }

        public virtual void EditorPreviewMouseMove(object sender, MouseEventArgs e)
        {
            // Implement your logic for EditorPreviewMouseMove event handling
        }

        public virtual void EditorPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic for EditorPreviewMouseUp event handling
        }

        public virtual void VertexMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic for VertexMouseDown event handling
        }

        public virtual void VertexMouseMove(object sender, MouseEventArgs e)
        {
            // Implement your logic for VertexMouseMove event handling
        }

        public virtual void VertexMouseUp(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic for VertexMouseUp event handling
        }

        public virtual void VertexPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic for VertexPreviewMouseDown event handling
        }

        public virtual void VertexPreviewMouseMove(object sender, MouseEventArgs e)
        {
            // Implement your logic for VertexPreviewMouseMove event handling
        }

        public virtual void VertexPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic for VertexPreviewMouseUp event handling
        }

        public virtual void EdgeMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic for EdgeMouseDown event handling
        }

        public virtual void EdgeMouseMove(object sender, MouseEventArgs e)
        {
            // Implement your logic for EdgeMouseMove event handling
        }

        public virtual void EdgeMouseUp(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic for EdgeMouseUp event handling
        }

        public virtual void EdgePreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic for EdgePreviewMouseDown event handling
        }

        public virtual void EdgePreviewMouseMove(object sender, MouseEventArgs e)
        {
            // Implement your logic for EdgePreviewMouseMove event handling
        }

        public virtual void EdgePreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            // Implement your logic for EdgePreviewMouseUp event handling
        }

        public virtual void EditorClicked(object sender, RoutedEventArgs e)
        {
            // Implement your logic for EditorClicked event handling
        }

        public virtual void EditorPreviewClicked(object sender, RoutedEventArgs e)
        {
            // Implement your logic for EditorPreviewClicked event handling
        }

        public virtual void VertexClicked(object sender, RoutedEventArgs e)
        {
            // Implement your logic for VertexClicked event handling
        }

        public virtual void VertexPreviewClicked(object sender, RoutedEventArgs e)
        {
            // Implement your logic for VertexPreviewClicked event handling
        }

        public virtual void EdgeClicked(object sender, RoutedEventArgs e)
        {
            // Implement your logic for EdgeClicked event handling
        }

        public virtual void EdgePreviewClicked(object sender, RoutedEventArgs e)
        {
            // Implement your logic for EdgePreviewClicked event handling
        }

    }
}
