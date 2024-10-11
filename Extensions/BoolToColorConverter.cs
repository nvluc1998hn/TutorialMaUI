using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialMaUI.Extensions
{
    /// <summary>
    /// Convert màu của button trang Login
    /// </summary>
    /// Author: lucnv
    /// Created: 11/10/2024

    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isEnabled = (bool)value;
            // Equivalent to: isEnabled ? Color1 : Color2
            return isEnabled ? Color.FromArgb("#41327B") : Color.FromArgb("#57606f");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return default;
        }
    }
}
