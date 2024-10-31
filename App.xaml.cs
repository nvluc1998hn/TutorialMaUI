using Common.Library.RestAPI;
using Syncfusion.Licensing;
using System.Globalization;
using TutorialMaUI.Extensions;
using TutorialMaUI.Views.Map;

namespace TutorialMaUI
{
    public partial class App : Application
    {
        private readonly IServiceCommunication _serviceCommunication;
        public App(IServiceCommunication serviceCommunication)
        {
            InitializeComponent();

            _serviceCommunication = serviceCommunication;

            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1NpR2FGfV5ycEVHYVZRRHxaSk0DNHVRdkdnWH9fdXZWRmBZWUBxX0c=");

            Translator.Instance.CultureInfo = new CultureInfo("");

            CultureInfo.CurrentUICulture = new CultureInfo("");

            var navigationPage = new NavigationPage(new Pages.StackLayOutDemo(_serviceCommunication));

            MainPage = new NavigationPage(new PinPageMap());

        }
    }
}
