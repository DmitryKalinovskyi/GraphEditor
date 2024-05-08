using GraphApplication.ModelViews;
using Microsoft.Extensions.DependencyInjection;
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

namespace GraphApplication.Views.Editor
{
    /// <summary>
    /// Interaction logic for Vertex.xaml
    /// </summary>
    public partial class Vertex : UserControl
    {
        public Vertex()
        {
            InitializeComponent();
        }

        private GraphProjectModelView GetProject()
        {
            // get from di container current project
            var ServiceProvider = (Application.Current as App).ServiceProvider;

            var mainWindowModelView = ServiceProvider.GetRequiredService<MainWindowModelView>();
            var manager = mainWindowModelView.OpenedGraphModelViewsManager;

            return manager.SelectedProject;
        }

        private void VertexButton_Click(object sender, RoutedEventArgs e)
        {
            GetProject().OnVertexClicked(sender, e);
        }

        private void VertexButton_MouseMove(object sender, MouseEventArgs e)
        {
            GetProject().OnVertexMouseMove(sender, e);
        }

        private void VertexButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            GetProject().OnVertexMouseUp(sender, e);
        }

        private void VertexButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GetProject().OnVertexMouseDown(sender, e);
        }
    }
}
