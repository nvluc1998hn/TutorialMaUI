using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace TutorialMaUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
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

            return builder.Build();
        }
    }
}
