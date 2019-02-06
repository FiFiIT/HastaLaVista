using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HastaLaVista.Conventers
{
    public class DateTimeToStringTimeConventer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime workDate;
            if(!DateTime.TryParse(value.ToString(), out workDate))
            {
                return value;
            }

            string hour = workDate.Hour.ToString("D2");
            string minute = workDate.Minute.ToString("D2");

            return $"{hour}:{minute}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime workDate;
            if (!DateTime.TryParse(value.ToString(), out workDate))
            {
                return value;
            }

            return workDate;
        }
    }
}
