using GraphApplication.ModelView;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphApplication.View
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
            (DataContext as GraphEditorModelView)?.MouseDown?.Invoke(sender, e);
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            (DataContext as GraphEditorModelView)?.MouseUp?.Invoke(sender, e);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            (DataContext as GraphEditorModelView)?.MouseMove?.Invoke(sender, e);
        }
    }
}
