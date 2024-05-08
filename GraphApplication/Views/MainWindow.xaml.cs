using GraphApplication.ModelViews;
using System.Windows;

namespace GraphApplication.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowModelView mainWindowModelView)
        {
            InitializeComponent();
            DataContext = mainWindowModelView;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (DataContext as MainWindowModelView).Window_Closing(sender, e);
        }
    }
}
