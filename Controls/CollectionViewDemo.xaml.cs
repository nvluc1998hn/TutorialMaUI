using TutorialMaUI.Models;
using TutorialMaUI.ViewModel;

namespace TutorialMaUI.Controls;

public partial class CollectionViewDemo : ContentPage
{
    public CollectionViewDemo()
    {
        InitializeComponent();
        collectionView.ItemsSource = GetCountries();
    }

    public UserViewModel ViewModel { get; set; }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        System.Diagnostics.Debugger.Break();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Set the Page BindingContext
        BindingContext = ViewModel;
    }

    private List<Country> GetCountries()
    {
        return new List<Country> {
            new Country(){ CountryName="Việt Nam", IsoCode="Vi-VN", FlagUrl="flagvietnam.jpg"},
            new Country(){ CountryName="English", IsoCode="en-EN", FlagUrl="flagenglish.svg"}
        };
    }
}