using TutorialMaUI.Models;

namespace TutorialMaUI.Views.Map;

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