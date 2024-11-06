namespace TutorialMaUI.ModelApi.Respond
{
    public class RouteDataViewModel
    {
        public List<RouteModel> Routes { get; set; }
    }

    public class RouteModel
    {
        public DateTime Time { get; set; }

        public double Lat { get; set; }

        public double Km { get; set; }

        public double Lng { get; set; }

        public double Velocity { get; set; }

        public string CurrentAddress { get; set; }
    }
}
