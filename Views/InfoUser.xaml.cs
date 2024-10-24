using Common.Library.RestAPI;
using TutorialMaUI.Extensions;
using TutorialMaUI.Service;

namespace TutorialMaUI.Views;

public partial class InfoUser : ContentPage
{

    public InfoUser()
    {
        var service = Singleton<CommonService>.Instance;
        BindingContext = service.InfoUser;
        InitializeComponent();
    }

    private async void LogOut(object sender, EventArgs e)
    {
        var _serviceCommunication = Application.Current.MainPage.Handler.MauiContext.Services.GetService<IServiceCommunication>();

        App.Current.MainPage = new NavigationPage(new LoginView(_serviceCommunication));
        await Navigation.PushAsync(new LoginView(_serviceCommunication));
    }
}