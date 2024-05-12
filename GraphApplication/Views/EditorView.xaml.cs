using GraphApplication.ModelViews;
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
