using System;
using System.Globalization;
using System.Windows.Data;

namespace BruPark.Apps.WPF.Converters
{
    [ValueConversion(typeof(int), typeof(string))]
    public class SuccessRateConverter : AbstractConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int input = System.Convert.ToInt32(value);

            if (input < 0)
            {
                return "";
            }
            else
            {
                return (input + " %");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
