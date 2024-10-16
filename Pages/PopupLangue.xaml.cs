using CommunityToolkit.Maui.Views;
using TutorialMaUI.Models;

namespace TutorialMaUI.Pages;

public partial class PopupLangue : Popup
{
    public event Action<Country> ItemSelected;

    public PopupLangue()
    {
        InitializeComponent();
        var dataCountry = GetCountries();
        collectionView.ItemsSource = dataCountry;
    }

    private List<Country> GetCountries()
    {
        return new List<Country> {
            new Country(){ CountryName="Việt Nam", IsoCode="", FlagUrl="flagvietnam.jpg"},
            new Country(){ CountryName="English", IsoCode="en-US", FlagUrl="flagenglish.svg"}
        };
    }

    private void onSelectItem(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = collectionView.SelectedItem as Country;
        if (selectedItem != null)
        {
            ItemSelected?.Invoke(selectedItem);
        }
        this.Close();
    }
}