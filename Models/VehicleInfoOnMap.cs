namespace TutorialMaUI.Models
{
    /// <summary>
    /// Thông tin xe trên map
    /// </summary>
    /// Author: lucnv
    /// Created: 04/11/2024
    /// Modified: date - user - description
    public class VehicleInfoOnMap
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        // Có hiển thị label hay không , auto = true
        public bool ShowLabel { get; set; } = true;
    }
}
