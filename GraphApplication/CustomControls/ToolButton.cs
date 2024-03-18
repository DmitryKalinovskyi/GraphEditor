using System.Windows;
using System.Windows.Controls;

namespace GraphApplication.CustomControls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:GraphApplication.CustomControls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:GraphApplication.CustomControls;assembly=GraphApplication.CustomControls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:ToolButton/>
    ///
    /// </summary>
    public class ToolButton : RadioButton
    {
        public string UriImage
        {
            get { return (string)GetValue(UriImageProperty); }
            set { SetValue(UriImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UriImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UriImageProperty =
            DependencyProperty.Register("UriImage", typeof(string), typeof(ToolButton), new PropertyMetadata(""));

        public string TipContent
        {
            get { return (string)GetValue(TipContentProperty); }
            set { SetValue(TipContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TipContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TipContentProperty =
            DependencyProperty.Register("TipContent", typeof(string), typeof(ToolButton), new PropertyMetadata(""));



        static ToolButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolButton), new FrameworkPropertyMetadata(typeof(ToolButton)));
        }
    }
}
