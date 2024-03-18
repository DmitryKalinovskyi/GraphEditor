using System;
using System.Globalization;
using System.Windows.Data;

namespace GraphApplication.Views
{
    public class ToolButtonCheckConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            if (parameter.ToString() == value.GetType().Name)
                return true;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
