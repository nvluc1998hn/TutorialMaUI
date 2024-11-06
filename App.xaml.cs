using Common.Library.RestAPI;
using Syncfusion.Licensing;
using System.Globalization;
using TutorialMaUI.Extensions;
using TutorialMaUI.Service.Interface;
using TutorialMaUI.Views;

namespace TutorialMaUI
{
    public partial class App : Application
    {
        private readonly IServiceCommunication _serviceCommunication;
        private readonly IAdminStaffService _adminStaffService;

        public App(IServiceCommunication serviceCommunication, IAdminStaffService adminStaffService)
        {
            InitializeComponent();

            _serviceCommunication = serviceCommunication;

            _adminStaffService = adminStaffService;

            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1NpR2FGfV5ycEVHYVZRRHxaSk0DNHVRdkdnWH9fdXZWRmBZWUBxX0c=");

            Translator.Instance.CultureInfo = new CultureInfo("");

            CultureInfo.CurrentUICulture = new CultureInfo("");

            var navigationPage = new NavigationPage(new Pages.StackLayOutDemo(_serviceCommunication));

            MainPage = new NavigationPage(new LoginView(_serviceCommunication));

        }
    }
}
