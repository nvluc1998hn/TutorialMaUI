using System.Globalization;

namespace TutorialMaUI.Extensions
{
    public class Base64ToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string base64String && !string.IsNullOrEmpty(base64String))
            {
                // Convert the Base64 string to a byte array
                var imageBytes = global::System.Convert.FromBase64String(base64String);
                // Create an ImageSource from the byte array
                return ImageSource.FromStream(() => new MemoryStream(imageBytes));
            }

            return null; // Return null if the value is not a valid Base64 string
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
