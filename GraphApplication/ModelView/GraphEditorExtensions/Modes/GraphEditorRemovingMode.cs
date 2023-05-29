using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GraphApplication.ModelView.GraphEditorExtensions.Modes
{
    public class GraphEditorRemovingMode : GraphEditorMode
    {
        public GraphEditorRemovingMode(GraphEditorModelView modelView) : base(modelView)
        {
        }



        public override void EdgeMouseDown(object sender, MouseButtonEventArgs e)
        {
            //get clicked edge
            EdgeModelView edgeModelView = (EdgeModelView)(sender as FrameworkElement).DataContext;


            Trace.WriteLine("Removed");
            _modelView.GraphModelView.EdgeModelViews.Remove(edgeModelView);
        }

        public override void VertexClicked(object sender, RoutedEventArgs e)
        {
            VertexModelView edgeModelView = (VertexModelView)(sender as FrameworkElement).DataContext;

            Trace.WriteLine("Removed");
            _modelView.GraphModelView.VertexModelViews.Remove(edgeModelView);
        }

    }
}
