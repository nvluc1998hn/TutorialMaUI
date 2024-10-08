using System.Globalization;
using TutorialMaUI.Pages;

namespace TutorialMaUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           // MainPage = new AppShell();

            var navigationPage = new NavigationPage(new StackLayOutDemo());

            MainPage = navigationPage;

            CultureInfo.CurrentUICulture = new CultureInfo("");
        }
    }
}
