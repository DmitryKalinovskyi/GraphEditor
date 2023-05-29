using GraphApplication.CustomControls;
using GraphApplication.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraphApplication.ModelView.GraphEditorExtensions.Modes
{
    public class GraphEditorSelectionMode : GraphEditorMode
    {
        public GraphEditorSelectionMode(GraphEditorModelView modelView) : base(modelView)
        {
        }

        public override void VertexClicked(object sender, RoutedEventArgs e)
        {
            if(sender is VertexButton vert && vert.DataContext is VertexModelView modelView)
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
