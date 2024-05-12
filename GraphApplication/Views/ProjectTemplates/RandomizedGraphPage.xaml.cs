using System.Windows;
using System.Windows.Controls;

namespace GraphApplication.Views.ProjectTemplates
{
    public partial class RandomizedGraphPage : Page
    {
        public RandomizedGraphPage()
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
