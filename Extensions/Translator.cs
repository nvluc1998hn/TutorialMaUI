using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using TutorialMaUI.Resources.Language;

namespace TutorialMaUI.Extensions
{
    public class Translator : INotifyPropertyChanged
    {
        public string this[string key]
        {
            get => AppResources.ResourceManager.GetString(key, CultureInfo);
        }

        public static Translator Instance { get; set; } = new Translator();

        public CultureInfo CultureInfo { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnPropetyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
