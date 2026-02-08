using System.Globalization;
using System.Windows.Data;

namespace Losowanie.Converters
{
    internal class PipsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(string))
            {
                if (value is List<int> pips)
                {
                    return string.Join(" ", pips);
                }
            }

            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}