using Common.Library.RestAPI;
using System.Globalization;
using TutorialMaUI.Extensions;
using TutorialMaUI.Pages;

namespace TutorialMaUI
{
    public partial class App : Application
    {
        private readonly IServiceCommunication _serviceCommunication;
        public App(IServiceCommunication serviceCommunication)
        {
            InitializeComponent();

            _serviceCommunication = serviceCommunication;

            var navigationPage = new NavigationPage(new StackLayOutDemo(_serviceCommunication));

            MainPage = navigationPage;

            Translator.Instance.CultureInfo = new CultureInfo("");

        }
    }
}
