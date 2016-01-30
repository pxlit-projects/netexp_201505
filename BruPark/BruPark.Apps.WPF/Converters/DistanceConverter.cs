using System;
using System.Globalization;
using System.Windows.Data;

namespace BruPark.Apps.WPF.Converters
{
    [ValueConversion(typeof(int), typeof(string))]
    public class DistanceConverter : AbstractConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int distance = System.Convert.ToInt32(value);

            double km = Math.Round((distance / 1000D), 2, MidpointRounding.AwayFromZero);

            return (km + " km");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
