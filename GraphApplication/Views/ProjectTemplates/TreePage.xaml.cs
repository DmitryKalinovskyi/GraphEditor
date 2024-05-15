using System.Windows;
using System.Windows.Controls;

namespace GraphApplication.Views.ProjectTemplates
{
    /// <summary>
    /// Interaction logic for TreePage.xaml
    /// </summary>
    public partial class TreePage : Page
    {
        public TreePage()
        {
            InitializeComponent();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            // Find the parent window
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                // Close the parent window
                parentWindow.Close();
            }
        }
    }
}
