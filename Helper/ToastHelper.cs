using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace TutorialMaUI.Helper
{
    /// <summary>
    /// Message thông báo
    /// </summary>
    /// Author: lucnv
    /// Created: 18/10/2024
    /// Modified: date - user - description
    public class ToastHelper
    {
        public static async void ShowNotificationToa(string message)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(message, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
    }
}
