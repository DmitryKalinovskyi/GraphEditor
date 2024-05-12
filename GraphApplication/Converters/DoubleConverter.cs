using System;
using System.Globalization;
using System.Windows.Data;

namespace GraphApplication.Converters
{
    public class DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double? @double = (double?)value;

            if (@double.HasValue)
            {
                return @double.Value.ToString("F2");
            }

            return "NaN";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
