using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GraphApplication.ModelView
{
    public partial class GraphEditorModelView
    {
        public void InitializeEvents()
        {

        }

        public void OnEditorClicked(object sender, RoutedEventArgs e)
        {
            CurrentEditorMode?.EditorClicked(sender, e);
        }

        public void OnEditorMouseMove(object sender, MouseEventArgs e)
        {
            CurrentEditorMode?.EditorMouseMove(sender, e);
        }

        public void OnEditorMouseUp(object sender, MouseButtonEventArgs e)
        {
            CurrentEditorMode?.EditorMouseUp(sender, e);
        }

        public void OnEditorMouseDown(object sender, MouseButtonEventArgs e)
        {
            CurrentEditorMode?.EditorMouseDown(sender, e);
        }

        public void OnVertexClicked(object sender, RoutedEventArgs e)
        {
            CurrentEditorMode?.VertexClicked(sender, e);
        }

        public void OnVertexMouseMove(object sender, MouseEventArgs e)
        {
            CurrentEditorMode?.VertexMouseMove(sender, e);
        }

        public void OnVertexMouseUp(object sender, MouseButtonEventArgs e)
        {
            CurrentEditorMode?.VertexMouseUp(sender, e);
        }

        public void OnVertexMouseDown(object sender, MouseButtonEventArgs e)
        {
            CurrentEditorMode?.VertexMouseDown(sender, e);
        }

        public void OnEdgeClicked(object sender, RoutedEventArgs e)
        {
            CurrentEditorMode?.EdgeClicked(sender, e);
        }

        public void OnEdgeMouseMove(object sender, MouseEventArgs e)
        {
            CurrentEditorMode?.EdgeMouseMove(sender, e);
        }

        public void OnEdgeMouseUp(object sender, MouseButtonEventArgs e)
        {
            CurrentEditorMode?.EdgeMouseUp(sender, e);
        }

        public void OnEdgeMouseDown(object sender, MouseButtonEventArgs e)
        {
            CurrentEditorMode?.EdgeMouseDown(sender, e);
        }
    }
}
