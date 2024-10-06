using TutorialMaUI.Pages;

namespace TutorialMaUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var navigationPage = new NavigationPage(new StackLayOutDemo());

            MainPage = navigationPage;
        }
    }
}
