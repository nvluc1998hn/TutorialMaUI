using Maui.GoogleMaps;

namespace TutorialMaUI.Views.Map;

public partial class PinPageMap : ContentPage
{
    private const double BaseLatitude = 20.976237;
    private const double BaseLongitude = 105.835532;
    private const int NumPins = 100;
    private const double OffsetRange = 0.01;
    private static readonly string[] iconVehicle = { "blackcar.png", "bluecar.png", "grayblue.png", "graycar.png", "greencar.png" }; // Danh sách chuỗi

    public PinPageMap()
    {
        InitializeComponent();

        map.InitialCameraUpdate = CameraUpdateFactory.NewPositionZoom(new Position(20.976237, 105.835532), 12d);

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await Task.Delay(1000); // workaround for #30 [Android]Map.Pins.Add doesn't work when page OnAppearing

        GenerateRandomPins();

    }

    private void GenerateRandomPins()
    {
        var random = new Random();

        //for (int i = 0; i < NumPins; i++)
        //{
        //    double latitudeOffset = (random.NextDouble() * 2 - 1) * OffsetRange;
        //    double longitudeOffset = (random.NextDouble() * 2 - 1) * OffsetRange;

        //    double latitude = BaseLatitude + latitudeOffset;
        //    double longitude = BaseLongitude + longitudeOffset;

        //    var pin = new Pin
        //    {
        //        Type = PinType.Generic,
        //        Label = $"Pin #{i + 1}",
        //        Address = $"Random Location {i + 1}",
        //        Position = new Position(latitude, longitude),
        //        Icon = BitmapDescriptorFactory.FromView(() => new BindingPinView2($"Pin #{i + 1}", GetRandomIcon()))
        //    };

        //    map.Pins.Add(pin);
        //}

        double latitudeOffset = (random.NextDouble() * 2 - 1) * OffsetRange;
        double longitudeOffset = (random.NextDouble() * 2 - 1) * OffsetRange;

        double latitude = BaseLatitude + latitudeOffset;
        double longitude = BaseLongitude + longitudeOffset;


        var pin = new Pin
        {
            Type = PinType.Generic,
            Label = "test",
            Address = $"Random Location ",
            Position = new Position(latitude, longitude),
            Icon = BitmapDescriptorFactory.FromView(() => new BindingPinView2($"test", GetRandomIcon()))
        };

        map.Pins.Add(pin);
    }

    public string GetRandomIcon()
    {
        var random = new Random();
        int index = random.Next(iconVehicle.Length - 1); // Lấy chỉ số ngẫu nhiên từ mảng
        return iconVehicle[index];
    }


}