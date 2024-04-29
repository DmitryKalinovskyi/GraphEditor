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
    ///     <MyNamespace:GraphArrow/>
    ///
    /// </summary>
    public class GraphArrow : Control
    {


        public double StartX
        {
            get { return (double)GetValue(StartXProperty); }
            set { SetValue(StartXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartXProperty =
            DependencyProperty.Register("StartX", typeof(double), typeof(GraphArrow), new PropertyMetadata(.0d, UpdateCenterX));

        

        public double StartY
        {
            get { return (double)GetValue(StartYProperty); }
            set { SetValue(StartYProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartY.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartYProperty =
            DependencyProperty.Register("StartY", typeof(double), typeof(GraphArrow), new PropertyMetadata(.0d, UpdateCenterY));



        public double EndX
        {
            get { return (double)GetValue(EndXProperty); }
            set { SetValue(EndXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EndX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EndXProperty =
            DependencyProperty.Register("EndX", typeof(double), typeof(GraphArrow), new PropertyMetadata(.0d, UpdateCenterX));



        public double EndY
        {
            get { return (double)GetValue(EndYProperty); }
            set { SetValue(EndYProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EndY.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EndYProperty =
            DependencyProperty.Register("EndY", typeof(double), typeof(GraphArrow), new PropertyMetadata(.0d, UpdateCenterY));



        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(GraphArrow), new PropertyMetadata(""));





        public double CenterX
        {
            get { return (double)GetValue(CenterXProperty); }
            protected set { SetValue(CenterXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CenterX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CenterXProperty =
            DependencyProperty.Register("CenterX", typeof(double), typeof(GraphArrow), new PropertyMetadata(.0d));



        public double CenterY
        {
            get { return (double)GetValue(CenterYProperty); }
            protected set { SetValue(CenterYProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CenterY.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CenterYProperty =
            DependencyProperty.Register("CenterY", typeof(double), typeof(GraphArrow), new PropertyMetadata(.0d));








        // readonly dp prop, about lenght
        // readonly dp prop, angle
        // readonly CenterX, CenterY

        // edge type? 


        static GraphArrow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GraphArrow), new FrameworkPropertyMetadata(typeof(GraphArrow)));
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
    }
}
