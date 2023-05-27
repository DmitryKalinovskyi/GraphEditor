using GraphApplication.View;
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

        public virtual void MouseDown(VertexView vertexModelView, MouseEventArgs e) { }
        public virtual void MouseMove(VertexView vertexModelView, MouseEventArgs e) { }
        public virtual void MouseUp(VertexView vertexModelView, MouseEventArgs e) { }

        public virtual void EditorDown(object sender, MouseEventArgs e) { }
        public virtual void EditorMove(object sender, MouseEventArgs e) { }
        public virtual void EditorUp(object sender, MouseEventArgs e) { }
    }
}
