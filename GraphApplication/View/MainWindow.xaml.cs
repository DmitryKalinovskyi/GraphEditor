using GraphApplication.Model;
using GraphApplication.ModelView;
using GraphApplication.Services;
using System.Windows;

namespace GraphApplication.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowModelView();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (DataContext as MainWindowModelView).Window_Closing(sender, e);
        }
    }
}
