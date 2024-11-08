namespace TutorialMaUI.Views.Map;

using Common.Library.Helper;
using Maui.GoogleMaps;
using Maui.GoogleMaps.Helpers;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TutorialMaUI.ModelApi.Respond;
using TutorialMaUI.Models;
using TutorialMaUI.Service.Interface;

/// <summary>
/// Thông tin lộ trình
/// </summary>
/// Author: lucnv
/// Created: 08/11/2024
/// Modified: date - user - description
public partial class Route : ContentPage, INotifyPropertyChanged
{
    private bool _disibleClick;

    public bool DisibleClick
    {
        get => _disibleClick;
        set
        {
            _disibleClick = value;
            OnPropertyChanged();
        }
    }

    private TimeSpan _startTime;

    public TimeSpan StartTime
    {
        get => _startTime;
        set
        {
            _startTime = value;
            OnPropertyChanged();
        }
    }

    private TimeSpan _endTime;

    public TimeSpan EndTime
    {
        get => _endTime;
        set
        {
            _endTime = value;
            OnPropertyChanged();
        }
    }

    private DateTime _selectedDate;

    public DateTime SelectedDate
    {
        get => _selectedDate;
        set
        {
            _selectedDate = value;
            OnPropertyChanged();
        }
    }

    private DateTime _selectedDateTo;

    public DateTime SelectedDateTo
    {
        get => _selectedDateTo;
        set
        {
            _selectedDateTo = value;
            OnPropertyChanged();
        }
    }

    public Route()
    {
        InitializeComponent();
        map.InitialCameraUpdate = CameraUpdateFactory.NewPositionZoom(new Position(20.976237, 105.835532), 12d);
        SelectedDate = new DateTime(2024, 06, 1, 00, 0, 0);
        SelectedDateTo = new DateTime(2024, 06, 1, 00, 0, 0);
        BindingContext = this;
    }

    public async Task<RouteDataViewModel> GetListRoute(IAdminStaffService adminStaffService, string fromDate, string toDate)
    {
        var listDataRoute = await adminStaffService.GetListRoute(fromDate, toDate);

        try
        {
            map.Polylines.Clear();
            map.Pins.Clear();

            var infoVehicleOnMap = new VehicleInfoOnMap()
            {
                ImageUrl = "grayblue.png",
                ShowLabel = false,
            };

            var pin = new Pin
            {
                Type = PinType.Generic,
                Label = "",
                Address = "",
                Rotation = (float)0,
                Position = new Position(0, 0),
                Icon = BitmapDescriptorFactory.FromView(() => new BindingPinView2(infoVehicleOnMap))
            };

            map.Pins.Add(pin);

            if (listDataRoute?.Routes?.Count > 0)
            {

                var result = listDataRoute?.Routes;

                #region Vẽ lộ trình dịch chuyển xe
                for (var i = 0; i < result.Count - 1; i++) // Lặp qua từng cặp điểm
                {
                    var routeStart = result[i];
                    var routeEnd = result[i + 1];

                    if (routeStart.Lat > 0 && routeStart.Lng > 0 && routeEnd.Lat > 0 && routeEnd.Lng > 0)
                    {
                        // Tạo polyline mới cho mỗi đoạn
                        var segmentPolyline = new Polyline
                        {
                            StrokeWidth = 1f,
                            StrokeColor = Colors.Red,
                        };

                        // Thêm hai điểm bắt đầu và kết thúc của đoạn vào polyline
                        segmentPolyline.Positions.Add(new Position(routeStart.Lat, routeStart.Lng));
                        segmentPolyline.Positions.Add(new Position(routeEnd.Lat, routeEnd.Lng));

                        // Thêm polyline này vào map
                        map.Polylines.Add(segmentPolyline);

                        // Tính hướng đi của xe
                        var eDirection = MapHelper.ComputeDirection(routeStart.Lat, routeStart.Lng, routeEnd.Lat, routeEnd.Lng);

                        // Cập nhật vị trí của pin
                        pin.Rotation = (float)eDirection;
                        pin.Position = new Position(routeEnd.Lat, routeEnd.Lng);

                        await Task.Delay(300);

                        var cameraUpdate = CameraUpdateFactory.NewPositionZoom(new Position(routeEnd.Lat, routeEnd.Lng), map.CameraPosition.Zoom);

                        // Di chuyển camera đến vị trí cua
                        await map.MoveCamera(cameraUpdate);

                    }
                }

                #endregion

                #region Vẽ lộ trình thuần k dịch chuyển theo xe, có polygon

                //double offsetDistance = 0.0001; // Khoảng cách cho đường bao xung quanh Polyline

                //var polyline1 = new Polyline
                //{
                //    StrokeWidth = 1f,
                //    StrokeColor = Colors.Red
                //};

                //var polygon = new Polygon()
                //{
                //    FillColor = Colors.Transparent,
                //    StrokeColor = Colors.Blue,
                //    StrokeWidth = 3f,
                //};

                //double currentMarkerKm = 0;

                //var arrowKmStep = 5;

                //for (var i = 0; i < result.Count - 1900; i++)
                //{
                //    var route = result[i];


                //    if (route.Lat > 0 && route.Lng > 0)
                //    {
                //        var position = new Position(route.Lat, route.Lng);
                //        polyline1.Positions.Add(position);
                //        polygon.Positions.Add(new Position(route.Lat + offsetDistance, route.Lng + offsetDistance));
                //    }

                //    // Điểm đầu
                //    if (i == 0)
                //    {
                //        var infoVehicleOnMap = new VehicleInfoOnMap()
                //        {
                //            ImageUrl = "pointgreen.png",
                //            ShowLabel = false,
                //        };

                //        var pin = new Pin
                //        {
                //            Type = PinType.Generic,
                //            Label = "Điểm bắt đầu",
                //            Address = "",
                //            Position = new Position(route.Lat, route.Lng),
                //            Icon = BitmapDescriptorFactory.FromView(() => new BindingPinView2(infoVehicleOnMap))
                //        };
                //        map.Pins.Add(pin);
                //    }

                //    // điểm cuối 
                //    if (i == result.Count - 1)
                //    {
                //        var infoVehicleOnMap = new VehicleInfoOnMap()
                //        {
                //            ImageUrl = "point.png",
                //            ShowLabel = false,
                //        };

                //        var pin = new Pin
                //        {
                //            Type = PinType.Generic,
                //            Label = "Điểm kết thúc",
                //            Address = "",
                //            Position = new Position(route.Lat, route.Lng),
                //            Icon = BitmapDescriptorFactory.FromView(() => new BindingPinView2(infoVehicleOnMap))
                //        };
                //        map.Pins.Add(pin);
                //    }
                //    else if (i > 0)
                //    {
                //        var prevRoute = result[i - 1];
                //        var eDirection = MapHelper.ComputeDirection(prevRoute.Lat, prevRoute.Lng, route.Lat, route.Lng);

                //        if (route.Km - currentMarkerKm > arrowKmStep)
                //        {
                //            currentMarkerKm = route.Km;

                //            var infoVehicleOnMap = new VehicleInfoOnMap()
                //            {
                //                ImageUrl = "caretup.png",
                //                ShowLabel = false,
                //            };
                //            var pin = new Pin
                //            {
                //                Type = PinType.Generic,
                //                Label = "",
                //                Address = "",
                //                Rotation = (float)eDirection,
                //                Position = new Position(route.Lat, route.Lng),
                //                Icon = BitmapDescriptorFactory.FromView(() => new BindingPinView2(infoVehicleOnMap))
                //            };
                //            map.Pins.Add(pin);
                //        }
                //    }

                //}

                //// Thêm điểm dưới của đường bao, để tạo thành vùng kín cho Polygon
                //for (var i = result.Count - 1; i >= 0; i--)
                //{
                //    var route = result[i];

                //    if (route.Lat > 0 && route.Lng > 0)
                //    {
                //        // Thêm điểm dưới của Polyline vào Polygon
                //        polygon.Positions.Add(new Position(route.Lat - offsetDistance, route.Lng - offsetDistance));
                //    }
                //}

                //map.Polylines.Add(polyline1);
                //map.Polygons.Add(polygon);

                //var positionFirst = new Position(result[0].Lat, result[0].Lng);

                //var poins = map.Polylines.SelectMany(c => c.Positions);

                //map.MoveToRegion(MapSpan.FromPositions(poins));

                #endregion

            }
        }
        catch (Exception ex)
        {
            LogHelper.Warning(ex.Message);
        }
        return listDataRoute;
    }


    private async void EnterSearch(object sender, TappedEventArgs e)
    {
        if (!DisibleClick)
        {
            var fromDate = $"{SelectedDate.Year}-{SelectedDate.Month.ToString("D2")}-{SelectedDate.Day.ToString("D2")}T{StartTime.Hours.ToString("D2")}:{StartTime.Minutes.ToString("D2")}:{StartTime.Seconds.ToString("D2")}";
            var toDateDate = $"{SelectedDateTo.Year}-{SelectedDateTo.Month.ToString("D2")}-{SelectedDateTo.Day.ToString("D2")}T{EndTime.Hours.ToString("D2")}:{EndTime.Minutes.ToString("D2")}:{EndTime.Seconds.ToString("D2")}";
            var adminStaffService = Application.Current.MainPage.Handler.MauiContext.Services.GetService<Service.Interface.IAdminStaffService>();

            DisibleClick = true;

            var result = await GetListRoute(adminStaffService, fromDate, toDateDate);


            DisibleClick = false;

            if (result?.Routes.Count == 0 || result == null)
            {
                await DisplayAlert("Thông báo", "Không có dữ liệu lộ trình", "OK");
            }
        }
        else
        {
            await DisplayAlert("Thông báo", "Đang tải dữ liệu", "OK");
        }

    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}