using TutorialMaUI.Models;

namespace TutorialMaUI.Controls;

public partial class CollectionViewDemo : ContentPage
{
	public CollectionViewDemo()
	{
		InitializeComponent();
        BindingContext = new CollectionViewDemoViewModel();
    }

}