using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace BruPark.Apps.WPF.Converters
{
    [ValueConversion(typeof(int), typeof(string))]
    public class DurationConverter : AbstractConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int duration = System.Convert.ToInt32(value);
            
            if (duration < 60)
            {
                return (duration + " sec.");
            }

            int minutes = (duration / 60);
            int seconds = (duration % 60);
            
            if (minutes < 60)
            {
                return (minutes + " min.");
            }

            int hours = (minutes / 60);

            minutes %= 60;

            StringBuilder result = new StringBuilder(8).Append(hours).Append(" hr");

            if (hours > 1)
            {
                result.Append('s');
            }

            result.Append('.');

            if (minutes > 0)
            {
                result.Append(' ').Append(minutes).Append(" min.");
            }

            return result.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
