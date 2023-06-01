using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphApplication.ModelView.GraphEditorExtensions.Modes
{
    public class GraphEditorHideMode : GraphEditorMode, IBuildingMode
    {
        public GraphEditorHideMode(GraphEditorModelView modelView) : base(modelView)
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
