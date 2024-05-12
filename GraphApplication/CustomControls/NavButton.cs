﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphApplication.CustomControls
{

    public class NavButton : Button
    {



        public Uri PageUri
        {
            get { return (Uri)GetValue(PageUriProperty); }
            set { SetValue(PageUriProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageUri.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageUriProperty =
            DependencyProperty.Register("PageUri", typeof(Uri), typeof(NavButton), new PropertyMetadata(null));



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(NavButton), new PropertyMetadata(""));




        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(NavButton), new PropertyMetadata(null));



        static NavButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavButton), new FrameworkPropertyMetadata(typeof(NavButton)));
        }
    }
}
