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
            selected = new List<VertexModelView>();
        }

        public List<VertexModelView> selected;

        public override void VertexClicked(object sender, RoutedEventArgs e)
        {
            if(sender is VertexButton vert && vert.DataContext is VertexModelView modelView)
            {
                if (selected.Contains(modelView))
                    Diselect(modelView);
                else
                    Select(modelView);
            }
        }


        private void Select(VertexModelView vertexModelView)
        {
            vertexModelView.IsSelected = true;
            selected.Add(vertexModelView);
        }

        private void Diselect(VertexModelView vertexModelView)
        {
            vertexModelView.IsSelected = false;
            selected.Remove(vertexModelView);
        }

        private void DiselectAll()
        {
            foreach(VertexModelView vertexModelView in selected)
            {
                vertexModelView.IsSelected = false;
            }

            selected.Clear();
        }

        public override void OnModeSwitch()
        {
            DiselectAll();
        }
    }
}
