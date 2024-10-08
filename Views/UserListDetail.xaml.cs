namespace TutorialMaUI.Views;

public partial class UserListDetail : ContentPage
{
	public UserListDetail()
	{
		InitializeComponent();
	}

    private async void navigateToDetail_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Views.UserDetailView));
    }
}