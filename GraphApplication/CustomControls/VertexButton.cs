using System.Windows;
using System.Windows.Controls;

namespace GraphApplication.CustomControls
{
    public class VertexButton : Button
    {
        //public bool UpdateCenterOnRadiusChange
        //{
        //    get { return (bool)GetValue(UpdateCenterOnRadiusChangeProperty); }
        //    set { SetValue(UpdateCenterOnRadiusChangeProperty, value); }
        //}

        //public static readonly DependencyProperty UpdateCenterOnRadiusChangeProperty =
        //    DependencyProperty.Register("UpdateCenterOnRadiusChange", typeof(bool), typeof(VertexButton), new PropertyMetadata(true));


        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(double), typeof(VertexButton), new PropertyMetadata(50d, OnRadiusUpdate));

        private static void OnRadiusUpdate(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            double radius = (double)d.GetValue(RadiusProperty);

            //if ((bool)d.GetValue(UpdateCenterOnRadiusChangeProperty))
            //{
            //    d.SetValue(CenterXProperty, radius / 2);
            //    d.SetValue(CenterYProperty, radius / 2);
            //}

            d.SetValue(CornerRadiusProperty, new CornerRadius(radius / 2));
        }

        //public double CenterX
        //{
        //    get { return (double)GetValue(CenterXProperty); }
        //    set { SetValue(CenterXProperty, value); }
        //}

        //public static readonly DependencyProperty CenterXProperty =
        //    DependencyProperty.Register("CenterX", typeof(double), typeof(VertexButton), new PropertyMetadata(25d));


        //public double CenterY
        //{
        //    get { return (double)GetValue(CenterYProperty); }
        //    set { SetValue(CenterYProperty, value); }
        //}

        //public static readonly DependencyProperty CenterYProperty =
        //    DependencyProperty.Register("CenterY", typeof(double), typeof(VertexButton), new PropertyMetadata(25d));




        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(VertexButton), new PropertyMetadata(""));





        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(VertexButton), new PropertyMetadata(new CornerRadius(25d)));





        static VertexButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VertexButton), new FrameworkPropertyMetadata(typeof(VertexButton)));
        }
    }
}
