using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphApplication.CustomControls
{
    public class AnimationButton : Button
    {
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(AnimationButton), new PropertyMetadata(null));



        static AnimationButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnimationButton), new FrameworkPropertyMetadata(typeof(AnimationButton)));
        }
    }
}
