using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HastaLaVista.Conventers
{
    public class DoubleToStringHour : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{value.ToString()}h";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!Double.TryParse(value.ToString(), out double retValue))
            {
                return value;
            }

            return retValue;
        }
    }
}
