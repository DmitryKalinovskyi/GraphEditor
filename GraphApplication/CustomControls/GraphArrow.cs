using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    public class GraphArrow : Arrow
    {


        public double HiddenStrokeThickness
        {
            get { return (double)GetValue(HiddenStrokeThicknessProperty); }
            set { SetValue(HiddenStrokeThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HiddenStrokeThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HiddenStrokeThicknessProperty =
            DependencyProperty.Register("HiddenStrokeThickness", typeof(double), typeof(GraphArrow), new PropertyMetadata(2d));



        public double HiddenOpacity
        {
            get { return (double)GetValue(HiddenOpacityProperty); }
            set { SetValue(HiddenOpacityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HiddenOpacity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HiddenOpacityProperty =
            DependencyProperty.Register("HiddenOpacity", typeof(double), typeof(GraphArrow), new PropertyMetadata(.2d));



        public static readonly DependencyProperty DefaultStrokeThicknessProperty =
            DependencyProperty.Register("DefaultStrokeThickness", typeof(double), typeof(GraphArrow), new PropertyMetadata(3d));

        public static readonly DependencyProperty ActiveStrokeThicknessProperty =
            DependencyProperty.Register("ActiveStrokeThickness", typeof(double), typeof(GraphArrow), new PropertyMetadata(5d));

        public static readonly DependencyProperty DefaultOpacityProperty =
            DependencyProperty.Register("DefaultOpacity", typeof(double), typeof(GraphArrow), new PropertyMetadata(.7d));

        public static readonly DependencyProperty ActiveOpacityProperty =
            DependencyProperty.Register("ActiveOpacity", typeof(double), typeof(GraphArrow), new PropertyMetadata(.9d));


        public double DefaultStrokeThickness
        {
            get { return (double)GetValue(DefaultStrokeThicknessProperty); }
            set { SetValue(DefaultStrokeThicknessProperty, value); }
        }

        public double ActiveStrokeThickness
        {
            get { return (double)GetValue(ActiveStrokeThicknessProperty); }
            set { SetValue(ActiveStrokeThicknessProperty, value); }
        }

        public double DefaultOpacity
        {
            get { return (double)GetValue(DefaultOpacityProperty); }
            set { SetValue(DefaultOpacityProperty, value); }
        }

        public double ActiveOpacity
        {
            get { return (double)GetValue(ActiveOpacityProperty); }
            set { SetValue(ActiveOpacityProperty, value); }
        }

        static GraphArrow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GraphArrow), new FrameworkPropertyMetadata(typeof(GraphArrow)));
        }
    }
}
