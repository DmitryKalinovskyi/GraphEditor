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
    ///     <MyNamespace:Arrow/>
    ///
    /// </summary>
    public class Arrow : Control
    {
        #region DependencyProperties


        public static readonly DependencyProperty StartXProperty =
            DependencyProperty.Register("StartX", typeof(double), typeof(Arrow), new PropertyMetadata(.0d, UpdateCenterX));

        public static readonly DependencyProperty StartYProperty =
            DependencyProperty.Register("StartY", typeof(double), typeof(Arrow), new PropertyMetadata(.0d, UpdateCenterY));

        public static readonly DependencyProperty EndXProperty =
            DependencyProperty.Register("EndX", typeof(double), typeof(Arrow), new PropertyMetadata(.0d, UpdateCenterX));

        public static readonly DependencyProperty EndYProperty =
            DependencyProperty.Register("EndY", typeof(double), typeof(Arrow), new PropertyMetadata(.0d, UpdateCenterY));

        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(Arrow), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty CenterXProperty =
            DependencyProperty.Register("CenterX", typeof(double), typeof(Arrow), new PropertyMetadata(.0d));

        public static readonly DependencyProperty CenterYProperty =
            DependencyProperty.Register("CenterY", typeof(double), typeof(Arrow), new PropertyMetadata(.0d));

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(Arrow), new PropertyMetadata(.1d));

        #endregion

        public double StartX
        {
            get { return (double)GetValue(StartXProperty); }
            set { SetValue(StartXProperty, value); }
        }

        public double StartY
        {
            get { return (double)GetValue(StartYProperty); }
            set { SetValue(StartYProperty, value); }
        }


        public double EndX
        {
            get { return (double)GetValue(EndXProperty); }
            set { SetValue(EndXProperty, value); }
        }

        public double EndY
        {
            get { return (double)GetValue(EndYProperty); }
            set { SetValue(EndYProperty, value); }
        }


        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }


        public double CenterX
        {
            get { return (double)GetValue(CenterXProperty); }
            protected set { SetValue(CenterXProperty, value); }
        }

        public double CenterY
        {
            get { return (double)GetValue(CenterYProperty); }
            protected set { SetValue(CenterYProperty, value); }
        }

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }


        private static void UpdateCenterX(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            double x1 = (double)d.GetValue(StartXProperty);
            double x2 = (double)d.GetValue(EndXProperty);
            double centerX = (x1 + x2) / 2;
            d.SetValue(CenterXProperty, centerX);
        }

        private static void UpdateCenterY(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            double y1 = (double)d.GetValue(StartYProperty);
            double y2 = (double)d.GetValue(EndYProperty);
            double centerY = (y1 + y2) / 2;
            d.SetValue(CenterYProperty, centerY);
        }

        static Arrow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Arrow), new FrameworkPropertyMetadata(typeof(Arrow)));
        }
    }
}
