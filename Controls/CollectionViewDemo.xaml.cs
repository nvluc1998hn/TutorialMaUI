using System.Globalization;
using TutorialMaUI.Models;
using TutorialMaUI.ViewModel;
using TutorialMAUI.Entity.EntityClass;

namespace TutorialMaUI.Controls;

public partial class CollectionViewDemo : ContentPage
{
    public CollectionViewDemo()
    {
        InitializeComponent();
        ViewModel = new UserViewModel();
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
}