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
    ///     <MyNamespace:Editor/>
    ///
    /// </summary>
    public class Editor : Control
    {
        //public static readonly DependencyProperty ViewportLocationProperty =
        //    DependencyProperty.Register("ViewportLocation", typeof(Point), typeof(Editor), new FrameworkPropertyMetadata(new Point(0, 0)));

        //public static readonly DependencyProperty ViewportSizeProperty =
        //    DependencyProperty.Register("ViewportSize", typeof(Size), typeof(Editor), new FrameworkPropertyMetadata(new Size(1, 1)));

        //private static readonly DependencyProperty viewportZoomProperty =
        //    DependencyProperty.Register("ViewportZoom", typeof(double), typeof(Editor), new FrameworkPropertyMetadata(1d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnViewportZoomChanged, ConstrainViewportZoomToRange));

        //public static readonly DependencyPropertyKey ViewportTransformPropertyKey =
        //    DependencyProperty.RegisterReadOnly("ViewportTransform", typeof(Transform), typeof(Editor), new PropertyMetadata(new TransformGroup()));

        //public static DependencyProperty ViewportZoomProperty => viewportZoomProperty;
        //public static readonly DependencyProperty ViewportTransformProperty = ViewportTransformPropertyKey.DependencyProperty;

        //public double ViewportZoom
        //{
        //    get { return (double)GetValue(ViewportZoomProperty); }
        //    set { SetValue(ViewportZoomProperty, value); }
        //}
        
        //public Point ViewportLocation
        //{
        //    get { return (Point)GetValue(ViewportLocationProperty); }
        //    set { SetValue(ViewportLocationProperty, value); }
        //}

        //public Size ViewportSize
        //{
        //    get { return (Size)GetValue(ViewportSizeProperty); }
        //    set { SetValue(ViewportSizeProperty, value); }
        //}

        //public Transform ViewportTransform
        //{
        //    get { return (Transform)GetValue(ViewportTransformProperty); }
        //    set { SetValue(ViewportTransformProperty, value); }
        //}

        //static Editor()
        //{
        //    DefaultStyleKeyProperty.OverrideMetadata(typeof(Editor), new FrameworkPropertyMetadata(typeof(Editor)));
        //}

        //private static void OnViewportZoomChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var editor = (Editor)d;
        //    double zoom = (double)e.NewValue;

        //    editor.ScaleTransform.ScaleX = zoom;
        //    editor.ScaleTransform.ScaleY = zoom;

        //    editor.ViewportSize = new Size(editor.ActualWidth / zoom, editor.ActualHeight / zoom);

        //    //editor.ApplyRenderingOptimizations();
        //    editor.OnViewportUpdated();
        //}

        //private static object ConstrainViewportZoomToRange(DependencyObject d, object value)
        //{
        //    var editor = (Editor)d;

        //    var num = (double)value;
        //    double minimum = editor.MinViewportZoom;
        //    if (num < minimum)
        //    {
        //        return minimum;
        //    }

        //    double maximum = editor.MaxViewportZoom;
        //    return num > maximum ? maximum : value;
        //}

        #region RenderingOptimizations
        //private void ApplyRenderingOptimizations()
        //{
        //    if (ItemsHost != null)
        //    {
        //        if (EnableRenderingContainersOptimizations && Items.Count >= OptimizeRenderingMinimumContainers)
        //        {
        //            double zoom = ViewportZoom;
        //            double availableZoomIn = 1.0 - MinViewportZoom;
        //            bool shouldCache = zoom / availableZoomIn <= OptimizeRenderingZoomOutPercent;
        //            ItemsHost.CacheMode = shouldCache ? new BitmapCache(1.0 / zoom) : null;
        //        }
        //        else
        //        {
        //            ItemsHost.CacheMode = null;
        //        }
        //    }
        //}
        #endregion

    }
}
