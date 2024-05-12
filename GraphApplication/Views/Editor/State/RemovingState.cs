using GraphApplication.Models;
using GraphApplication.ModelViews;
using GraphApplication.Views.Editor.State.Base;
using System.Windows;
using System.Windows.Input;

namespace GraphApplication.Views.Editor.State
{
    public class RemovingState : EditorState, IBuildingMode
    {
        public RemovingState(GraphProjectModelView modelView) : base(modelView) { }

        public override void EdgeMouseDown(object sender, MouseButtonEventArgs e)
        {
            EdgeModelView edgeModelView = (EdgeModelView)(sender as FrameworkElement).DataContext;

            if (edgeModelView != null)
            {
                _modelView.GraphModelView.RemoveEdgeCommand.Execute(edgeModelView.Model);
            }
        }

        public override void VertexClicked(object sender, RoutedEventArgs e)
        {
            VertexModelView vertexModleView = (VertexModelView)(sender as FrameworkElement).DataContext;

            VertexModel model = vertexModleView.Model;

            _modelView.GraphModelView.RemoveVertexCommand.Execute(model);
        }
    }
}
