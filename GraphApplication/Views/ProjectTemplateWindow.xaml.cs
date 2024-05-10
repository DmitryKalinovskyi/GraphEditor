using GraphApplication.ModelViews;
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
using System.Windows.Shapes;

namespace GraphApplication.Views
{
    /// <summary>
    /// Interaction logic for ProjectTemplateWindow.xaml
    /// </summary>
    public partial class ProjectTemplateWindow : Window
    {
        private MainWindowModelView _mainWindowModelView;

        public ProjectTemplateWindow(MainWindowModelView mainWindowModelView)
        {
            InitializeComponent();
            _mainWindowModelView = mainWindowModelView;
        }
    }
}
