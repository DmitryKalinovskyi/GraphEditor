using GraphApplication.ModelViews;
using System.Windows;

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
