using GraphApplication.CustomControls;
using GraphApplication.ModelViews;
using GraphApplication.Views.Editor.State.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraphApplication.Views.Editor.State
{
    public class SelectionState : EditorState
    {
        public SelectionState(GraphProjectModelView modelView) : base(modelView)
        {
        }

        public override void VertexClicked(object sender, RoutedEventArgs e)
        {
            if (sender is VertexButton vert && vert.DataContext is VertexModelView modelView)
            {
                _modelView.SelectionManager.Select(modelView);
            }
        }

        public override void EditorMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Canvas)
                _modelView.SelectionManager.DiselectAll();
        }


        public override void OnModeSwitch()
        {
        }
    }
}
