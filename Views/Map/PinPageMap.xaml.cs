using Maui.GoogleMaps;
using Maui.GoogleMaps.Behaviors;
using Maui.GoogleMaps.Clustering.Logics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TutorialMaUI.Models;

namespace TutorialMaUI.Views.Map;

/// <summary>
///  Pin trên map
/// </summary>
/// Author: lucnv
/// Created: 08/11/2024
/// Modified: date - user - description
/// 
public partial class PinPageMap : ContentPage, INotifyPropertyChanged
{
    private const double BaseLatitude = 20.976237;
    private const double BaseLongitude = 105.835532;
    private const int NumPins = 50;
    private List<Pin> LsPins = new List<Pin>();

    private string _vehiclePlate;

    public string VehiclePlate
    {
        get => _vehiclePlate;
        set
        {
            _vehiclePlate = value;
            OnPropertyChanged();
        }
    }

    public AnimateCameraRequest AnimateCameraRequest { get; } = new AnimateCameraRequest();

    private const double OffsetRange = 0.03;
    private static readonly string[] iconVehicle = { "blackcar.png", "bluecar.png", "grayblue.png", "graycar.png", "greencar.png" }; // Danh sách chuỗi
    public PinPageMap()
    {
        InitializeComponent();
        map.ClusterOptions.SetMinimumClusterSize(5);
        map.ClusterOptions.SetMaxDistanceBetweenClusteredItems(100); // android only
        map.InitialCameraUpdate = CameraUpdateFactory.NewPositionZoom(new Position(20.976237, 105.835532), 12d);
        GenerateRandomPins();
        BindingContext = this;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


    // Tạo n điểm tự động random theo vị trí
    private void GenerateRandomPins()
    {
        var random = new Random();

        for (int i = 0; i < NumPins; i++)
        {
            double latitudeOffset = (random.NextDouble() * 2 - 1) * OffsetRange;
            double longitudeOffset = (random.NextDouble() * 2 - 1) * OffsetRange;
            string randomNumberPlate = random.Next(1, 1000000).ToString("D6");

            double latitude = BaseLatitude + latitudeOffset;
            double longitude = BaseLongitude + longitudeOffset;
            int pinIndex = i;
            var infoVehicleOnMap = new VehicleInfoOnMap()
            {
                ImageUrl = GetRandomIcon(),
                Title = $"29L1- {randomNumberPlate}",
            };
            var pin = new Pin
            {
                Type = PinType.Generic,
                Label = infoVehicleOnMap.Title,
                Address = $"Random Location {i + 1}",
                Position = new Position(latitude, longitude),
                Icon = BitmapDescriptorFactory.FromView(() => new BindingPinView2(infoVehicleOnMap))
            };
            map.Pins.Add(pin);
        }
    }

    public string GetRandomIcon()
    {
        var random = new Random();
        int index = random.Next(iconVehicle.Length - 1); // Lấy chỉ số ngẫu nhiên từ mảng
        return iconVehicle[index];
    }

    private void Map_ClusterClicked(object sender, ClusterClickedEventArgs e)
    {
        // Lấy vị trí trung tâm của cụm
        var clusterCenter = e.Position;

        // Tạo mức zoom vào vị trí cụm để mở rộng các điểm bên trong
        var cameraUpdate = CameraUpdateFactory.NewPositionZoom(clusterCenter, map.CameraPosition.Zoom + 2);

        // Di chuyển camera đến vị trí đã zoom
        map.MoveCamera(cameraUpdate);

        // Hủy sự kiện để không chọn thêm các điểm khác
        e.Handled = true;
    }

    private async void EnterSearch(object sender, TappedEventArgs e)
    {
        var findPoin = map.Pins.Where(c => c.Label == VehiclePlate)?.FirstOrDefault();
        if (findPoin != null)
        {
            // Span to đến điểm đó
            AnimateCameraRequest.AnimateCamera(CameraUpdateFactory.NewPositionZoom(new Position(findPoin.Position.Latitude, findPoin.Position.Longitude), map.CameraPosition.Zoom + 2));
        }
        else
        {
            await DisplayAlert("Thông báo", "Không có thông tin xe", "OK");
        }
    }

}