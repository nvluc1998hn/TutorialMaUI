using System.Collections.ObjectModel;
using System.ComponentModel;
using TutorialMaUI.Models;

namespace TutorialMaUI.ViewModel.Respond
{
    public class CountryTest : INotifyPropertyChanged
    {
        private ObservableCollection<Country> _records;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Country> Records
        {
            get => _records;
            set
            {
                _records = value;
                OnPropertyChanged(nameof(Records));
            }

        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CountryTest()
        {
            Records = new ObservableCollection<Country>
        {
            new Country { CountryName = "1", FlagUrl = "flagenglish.svg" },
            new Country { CountryName = "2", FlagUrl = "flagenglish.svg" },
            new Country { CountryName = "3", FlagUrl = "flagenglish.svg" },
            new Country { CountryName = "4", FlagUrl = "flagenglish.svg" },
            new Country { CountryName = "5", FlagUrl = "flagenglish.svg" },
            new Country { CountryName = "6 States", FlagUrl = "flagenglish.svg" },
            new Country { CountryName = "7", FlagUrl = "flagenglish.svg" },
            new Country { CountryName = "8", FlagUrl = "flagenglish.svg" },
            new Country { CountryName = "9", FlagUrl = "flagenglish.svg" },
            new Country { CountryName = "10", FlagUrl = "flagenglish.svg" },
            new Country { CountryName = "11 States", FlagUrl = "flagenglish.svg" },
            new Country { CountryName = "12", FlagUrl = "flagenglish.svg" },
            new Country { CountryName = "13", FlagUrl = "flagenglish.svg" },
        };
        }
    }
}
