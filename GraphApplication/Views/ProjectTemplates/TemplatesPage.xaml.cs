using GraphApplication.CustomControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace GraphApplication.Views.ProjectTemplates
{
    /// <summary>
    /// Interaction logic for TemplatesPage.xaml
    /// </summary>
    public partial class TemplatesPage : Page
    {
        public TemplatesPage()
        {
            InitializeComponent();
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            var navButton = e.Source as NavButton;
            if (navButton != null)
            {
                NavigationService.Navigate(navButton.PageUri);
            }
        }
    }
}
