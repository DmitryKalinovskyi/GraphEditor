using GraphApplication.Models;
using GraphApplication.ModelViews;
using GraphApplication.Views.Editor.State.Base;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace GraphApplication.Views.Editor.State
{
    public class RemovingState : EditorState, IBuildingMode
    {
        public RemovingState(GraphProjectModelView modelView) : base(modelView)
        {
        }



        public override void EdgeMouseDown(object sender, MouseButtonEventArgs e)
        {
            //get clicked edge
            Trace.WriteLine("Edge removing..");

            EdgeModelView edgeModelView = (EdgeModelView)(sender as FrameworkElement).DataContext;

            if (edgeModelView != null)
            {
                _modelView.GraphModelView.RemoveEdgeCommand.Execute(edgeModelView.Model);
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

            VertexModel model = vertexModleView.Model;

            _modelView.GraphModelView.RemoveVertexCommand.Execute(model);
        }

    }
}
