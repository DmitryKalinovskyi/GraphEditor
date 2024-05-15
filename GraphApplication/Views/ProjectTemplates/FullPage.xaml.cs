using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GraphApplication.Views.ProjectTemplates
{
    /// <summary>
    /// Interaction logic for FullPage.xaml
    /// </summary>
    public partial class FullPage : Page
    {
        public FullPage()
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
