using Android.Content.Res;
using Android.Graphics.Drawables;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using TutorialMaUI.Controls.CustomControls;

namespace TutorialMaUI.Platforms.Android;

public partial class CustomEntryHandler : EntryHandler

{
    static IPropertyMapper<StandarEntry, CustomEntryHandler> PropertyMapper = new PropertyMapper<StandarEntry, CustomEntryHandler>(ViewHandler.ViewMapper)
    {
        // [nameof(StandarEntry.NoUnderline)] = MapNoUnderlineProperty,
        [nameof(StandarEntry.BorderColor)] = MapBorderColor,
    };

    public CustomEntryHandler() : base(PropertyMapper) { }

    static void MapNoUnderlineProperty(CustomEntryHandler handler, StandarEntry entry)
    {
        if (entry.NoUnderline)
            handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
        else
            handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
    }

    static void MapBorderColor(CustomEntryHandler handler, StandarEntry entry)
    {
        var borderColor = entry.BorderColor.ToAndroid();
        var border = new GradientDrawable();
        border.SetColor(Colors.White.ToAndroid()); // Màu nền
        border.SetStroke(2, borderColor); // Độ dày và màu viền
        border.SetCornerRadius(10); // Điều chỉnh bán kính góc nếu cần
        handler.PlatformView.SetBackground(border);

        var paddingPx = (int)handler.PlatformView.Context.ToPixels(5); // Chuyển đổi từ dp sang px
        handler.PlatformView.SetPadding(paddingPx, paddingPx, paddingPx, paddingPx);
    }
}
