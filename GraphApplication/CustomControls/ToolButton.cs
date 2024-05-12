using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphApplication.CustomControls
{
    public class ToolButton : RadioButton
    {
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ToolButton), new PropertyMetadata(null));


        public string TipContent
        {
            get { return (string)GetValue(TipContentProperty); }
            set { SetValue(TipContentProperty, value); }
        }

        public static readonly DependencyProperty TipContentProperty =
            DependencyProperty.Register("TipContent", typeof(string), typeof(ToolButton), new PropertyMetadata(""));



        static ToolButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolButton), new FrameworkPropertyMetadata(typeof(ToolButton)));
        }
    }
}
