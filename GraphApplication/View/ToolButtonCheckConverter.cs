using GraphApplication.ModelView.GraphEditorExtensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GraphApplication.View
{
    public class ToolButtonCheckConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            if(parameter.ToString() == value.GetType().Name)
                return true;

            return false;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           // GraphEditorMode mode = EditorModeConverter.Convert(parameter as string);

            return null;
        }
    }
}
