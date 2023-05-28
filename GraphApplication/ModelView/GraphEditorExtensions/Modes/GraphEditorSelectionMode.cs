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

namespace GraphApplication.ModelView.GraphEditorExtensions
{
    class GraphEditorSelectionMode : GraphEditorMode
    {
        public GraphEditorSelectionMode(GraphEditorModelView modelView) : base(modelView)
        {
            selected = new List<VertexModelView>();
        }

        //simulate click

        //VertexView? startClickObject;

        //List<VertexView> selected;

        //public override void MouseDown(VertexView vertexModelView, MouseEventArgs e)
        //{
        //    startClickObject = vertexModelView;
        //}

        //public override void MouseUp(VertexView vertexModelView, MouseEventArgs e)
        //{
        //    if(vertexModelView == startClickObject)
        //    {
        //        (vertexModelView.DataContext as VertexModelView).IsSelected = true;
        //        selected.Add(vertexModelView);

        //        Trace.WriteLine("Selected!");
        //    }


        //    startClickObject = null;
        //}

        //public override void EditorUp(object sender, MouseEventArgs e)
        //{
        //    Trace.WriteLine("Diselect all");

        //    foreach(var vertexModelView in selected)
        //    {
        //        (vertexModelView.DataContext as VertexModelView).IsSelected = false;
        //    }

        //    selected.Clear();
        //}

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
    }
}
