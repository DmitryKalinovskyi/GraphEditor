using GraphApplication.View;
using System.Windows.Input;

namespace GraphApplication.ModelView.Extensions
{
    public abstract class GraphEditorMode
    {

        private readonly GraphEditorModelView _modelView;
        public GraphEditorMode(GraphEditorModelView modelView)
        {
            _modelView = modelView;
        }

        public virtual void MouseDown(VertexView vertexModelView, MouseEventArgs e) { }
        public virtual void MouseMove(VertexView vertexModelView, MouseEventArgs e) { }
        public virtual void MouseUp(VertexView vertexModelView, MouseEventArgs e) { }
        public virtual void Click(VertexView vertexModelView, MouseEventArgs e) { }


    }
}
