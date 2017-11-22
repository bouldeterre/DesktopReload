using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Shapes;

namespace DesktopReload.Converters
{
    public class ValueToGraphWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double valueIn = System.Convert.ToDouble(value);
                double result = 0;
                var backgroundWidth = ((Rectangle)parameter).ActualWidth;
                result = backgroundWidth / 100 * valueIn;
                return result;
            }
            catch (Exception e)
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valueIn = (int)value;

            return valueIn;
        }
    }
}
