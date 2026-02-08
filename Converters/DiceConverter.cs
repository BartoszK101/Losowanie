using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Losowanie.Converters
{
    internal class DiceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(ImageSource))
            {
                if (value is int pipsCount)
                {
                    return pipsCount switch
                    {
                        1 => "/Images/k1.jpg",
                        2 => "/Images/k2.jpg",
                        3 => "/Images/k3.jpg",
                        4 => "/Images/k4.jpg",
                        5 => "/Images/k5.jpg",
                        6 => "/Images/k6.jpg",
                        _ => "/Images/question.jpg",
                    };
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