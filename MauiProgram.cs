using Common.Library.RestAPI;
using CommunityToolkit.Maui;
using Maui.GoogleMaps.Clustering.Hosting;
using Maui.GoogleMaps.Hosting;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using TutorialMaUI.Extensions;
using TutorialMaUI.Service;
using TutorialMaUI.Service.Interface;


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
                .ConfigureSyncfusionCore()
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

#if ANDROID
            var platformConfig = new Maui.GoogleMaps.Android.PlatformConfig
            {
                BitmapDescriptorFactory = new TutorialMaUI.Platforms.Android.CachingNativeBitmapDescriptorFactory()
            };

            builder.UseGoogleMaps(platformConfig);
#elif IOS
            var platformConfig = new Maui.GoogleMaps.iOS.PlatformConfig
            {
                ImageFactory = new Platforms.iOS.CachingImageFactory()
            };

            builder.UseGoogleMaps(Variables.GOOGLE_MAPS_IOS_API_KEY, platformConfig);
#endif


            builder.ConfigureMauiHandlers((handlers) =>
             {
                 handlers.ConfigureHandlers();
#if ANDROID
                 handlers.AddHandler<Controls.CustomControls.StandarEntry, TutorialMaUI.Platforms.Android.CustomEntryHandler>();


#endif
             });

            Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("EditorCustomization", (handler, view) =>
            {
#if ANDROID
                // Remove underline on Android
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#endif
            });

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
            {
                if (view is Controls.CustomControls.StandarEntry)
                {
#if ANDROID
                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
                }
            });

            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
            {

#if ANDROID
                handler.PlatformView.BackgroundTintList =
    Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#endif
            });

            Microsoft.Maui.Handlers.TimePickerHandler.Mapper.AppendToMapping("MyCustomization2", (handler, view) =>
            {

#if ANDROID
                handler.PlatformView.BackgroundTintList =
    Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#endif
            });



            builder.Services.AddSingleton<IServiceCommunication, ServiceCommunication>();
            builder.Services.AddSingleton<IAdminStaffService, AdminStaffService>();

            builder.Services.AddHttpClient();
            builder.UseGoogleMapsClustering();

            return builder.Build();
        }
    }
}
