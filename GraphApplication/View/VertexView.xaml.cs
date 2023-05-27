using GraphApplication.Model;
using GraphApplication.ModelView;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for VertexView.xaml
    /// </summary>
    public partial class VertexView : UserControl
    {
        public VertexView()
        {
            InitializeComponent();
        }


        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (DataContext as VertexModelView)?.MouseDown?.Invoke(this, e);
        }

        private void Ellipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            (DataContext as VertexModelView)?.MouseUp?.Invoke(this, e);
        }

        private void Ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            (DataContext as VertexModelView)?.MouseMove?.Invoke(this, e);
        }
    }
}
