using System;
using System.Globalization;
using System.Windows.Data;

namespace GraphApplication.Converters
{
    public class CenterTranslateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double)
            {
                double input = (double)value;
                return -input / 2.0;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
