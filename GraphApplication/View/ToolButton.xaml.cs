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

namespace GraphApplication.View
{
    /// <summary>
    /// Interaction logic for ToolButton.xaml
    /// </summary>
    public partial class ToolButton : UserControl
    {
        public string UriImage
        {
            get { return (string)GetValue(UriImageProperty); }
            set { SetValue(UriImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UriImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UriImageProperty =
            DependencyProperty.Register("UriImage", typeof(string), typeof(ToolButton), new PropertyMetadata(""));



        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(ToolButton), new PropertyMetadata(false));



        public ToolButton()
        {
            InitializeComponent();

            DataContext = this;
        }
    }
}
