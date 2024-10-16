using Common.Library.RestAPI;
using TutorialMaUI.Controls;
using TutorialMaUI.Views;

namespace TutorialMaUI.Pages;

public partial class StackLayOutDemo : ContentPage
{
    private readonly IServiceCommunication _serviceCommunication;

    public StackLayOutDemo(IServiceCommunication serviceCommunication)
    {
        _serviceCommunication = serviceCommunication;
        InitializeComponent();
    }

    private void gridButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new GridLayOutDemo());
    }

    private void gridButtonFlex_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FlexLayOutDemo());
    }

    private void collection_LayOut(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CollectionViewDemo());
    }

    private void loginView_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginView(_serviceCommunication));
    }
}