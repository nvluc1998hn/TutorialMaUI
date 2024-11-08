using TutorialMaUI.Models;

namespace TutorialMaUI.Views.Map;

/// <summary>
/// Template để hiện thị thông tin của Pin
/// </summary>
/// Author: lucnv
/// Created: 08/11/2024
public partial class BindingPinView2 : Grid
{
    private VehicleInfoOnMap _infoVehicleOnMap;

    public BindingPinView2(VehicleInfoOnMap infoVehicleOnMap)
    {
        _infoVehicleOnMap = infoVehicleOnMap;
        InitializeComponent();

        BindingContext = _infoVehicleOnMap;
    }
    public VehicleInfoOnMap InfoVehicleOnMap
    {
        get { return _infoVehicleOnMap; }
    }

}