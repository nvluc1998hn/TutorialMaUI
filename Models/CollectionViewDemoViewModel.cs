

using System.ComponentModel;

namespace TutorialMaUI.Models
{
    public class CollectionViewDemoViewModel : INotifyPropertyChanged
    {
        private List<Country> _countries;
        public List<Country> Countries
        {
            get => _countries;
            set
            {
                _countries = value;
                OnPropertyChanged(nameof(Countries));
            }
        }

        private Country _selectedCountry;
        public Country SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
                OnPropertyChanged(nameof(SelectedCountry));
            }
        }

        public CollectionViewDemoViewModel()
        {
            Countries = GetCountries();
        }

        private List<Country> GetCountries()
        {
            return new List<Country> {
            new Country(){ CountryName="Canada", IsoCode="CAN", FlagUrl="https://vi.wikipedia.org/wiki/Canada"},
            new Country(){ CountryName="USA", IsoCode="USA", FlagUrl="https://vi.wikipedia.org/wiki/USA"},
            new Country(){ CountryName="Malaysia", IsoCode="MY", FlagUrl="https://vi.wikipedia.org/wiki/Malaysia"},
            new Country(){ CountryName="Singapore", IsoCode="SG", FlagUrl="https://vi.wikipedia.org/wiki/Singapore"},
            new Country(){ CountryName="Poland", IsoCode="PL", FlagUrl="https://vi.wikipedia.org/wiki/Poland"}
        };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Country
    {
        public string CountryName { get; set; }
        public string IsoCode { get; set; }
        public string FlagUrl { get; set; }
    }
}
