using TutorialMaUI.Controls;
using TutorialMaUI.Views;

namespace TutorialMaUI.Pages;

public partial class StackLayOutDemo : ContentPage
{
	public StackLayOutDemo()
	{
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
        Navigation.PushAsync(new LoginView());
    }
}