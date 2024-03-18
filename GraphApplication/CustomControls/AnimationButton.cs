﻿using System.Windows;
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
    ///     <MyNamespace:AnimationButton/>
    ///
    /// </summary>
    /// 

    public class AnimationButton : Button
    {


        public string UriImage
        {
            get { return (string)GetValue(UriImageProperty); }
            set { SetValue(UriImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UriImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UriImageProperty =
            DependencyProperty.Register("UriImage", typeof(string), typeof(AnimationButton), new PropertyMetadata(""));



        static AnimationButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnimationButton), new FrameworkPropertyMetadata(typeof(AnimationButton)));
        }
    }
}
