using Common.Library.RestAPI;
using Syncfusion.Licensing;
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

            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1NpR2FGfV5ycEVHYVZRRHxaSk0DNHVRdkdnWH9fdXZWRmBZWUBxX0c=");

            Translator.Instance.CultureInfo = new CultureInfo("");

            CultureInfo.CurrentUICulture = new CultureInfo("");

        }
    }
}
