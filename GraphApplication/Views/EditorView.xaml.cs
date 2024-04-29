﻿using GraphApplication.ModelViews;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GraphApplication.Views
{
    /// <summary>
    /// Interaction logic for GraphEditorView.xaml
    /// </summary>
    public partial class GraphEditorView : UserControl
    {
        public GraphEditorView()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (DataContext as GraphProjectModelView)?.OnEditorMouseDown(sender, e);
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            (DataContext as GraphProjectModelView)?.OnEditorMouseUp(sender, e);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            (DataContext as GraphProjectModelView)?.OnEditorMouseMove(sender, e);
        }

        private void VertexButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as GraphProjectModelView)?.OnVertexClicked(sender, e);
        }

        private void VertexButton_MouseMove(object sender, MouseEventArgs e)
        {
            (DataContext as GraphProjectModelView)?.OnVertexMouseMove(sender, e);
        }

        private void VertexButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            (DataContext as GraphProjectModelView)?.OnVertexMouseUp(sender, e);
        }

        private void VertexButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (DataContext as GraphProjectModelView)?.OnVertexMouseDown(sender, e);
        }

        private void VertexButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            // (DataContext as GraphEditorModelView)?.(sender, e);
        }

        private void VertexButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //   (DataContext as GraphEditorModelView)?.OnVertexClicked(sender, e);
        }

        private void VertexButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Line_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (DataContext as GraphProjectModelView)?.OnEdgeMouseDown(sender, e);

        }

        private void Line_MouseUp(object sender, MouseButtonEventArgs e)
        {
            (DataContext as GraphProjectModelView)?.OnEdgeMouseUp(sender, e);

        }

        private void Line_MouseMove(object sender, MouseEventArgs e)
        {
            (DataContext as GraphProjectModelView)?.OnEdgeMouseMove(sender, e);
        }

        //якісь інші події
    }
}