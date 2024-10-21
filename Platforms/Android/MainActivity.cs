using Android.App;
using Android.Content.PM;

namespace TutorialMaUI
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    Window.SetStatusBarColor(Android.Graphics.Color.Orange);
        //    Window.SetNavigationBarColor(Android.Graphics.Color.Green);
        //    Window.SetTitleColor(Android.Graphics.Color.Orange);
        //    base.OnCreate(savedInstanceState);
        //}
    }
}
