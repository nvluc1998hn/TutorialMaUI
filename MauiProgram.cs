using Common.Library.RestAPI;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Syncfusion.Maui.Core.Hosting;
using TutorialMaUI.Extensions;

namespace TutorialMaUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa-brands-400.ttf", "FontAwesome");
                });


#if DEBUG
            builder.Logging.AddDebug();
            builder.ConfigureSyncfusionCore();
#endif
            builder.ConfigureMauiHandlers((handlers) =>
             {
                 handlers.ConfigureHandlers();
             });

            builder.Services.AddSingleton<IServiceCommunication, ServiceCommunication>();
            builder.Services.AddHttpClient();


            return builder.Build();
        }
    }
}
