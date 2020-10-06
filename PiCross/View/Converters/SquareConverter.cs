using PiCross;
using System;
using System.Globalization;
using System.Windows.Data;

namespace View
{
    //square converter to filled empty or unknown
    public class SquareConverter : IValueConverter
    {
        public object Filled { get; set; }
        public object Empty { get; set; }
        public object Unknown { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var square = (Square)value;

            if (square == Square.EMPTY)
            {
                return Empty;
            }

            else if (square == Square.FILLED)
            {
                return Filled;
            }

            else
            {
                return Unknown;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}