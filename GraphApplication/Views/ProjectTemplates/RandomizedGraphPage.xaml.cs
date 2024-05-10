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
