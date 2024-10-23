namespace TutorialMaUI.ViewModel.Respond
{
    public class AdminStaffResponse
    {
        public int Id { get; set; }

        public string StaffCode { get; set; }

        public string StaffName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        public string Image { get; set; }

        public int Part { get; set; }

        public string PartName { get; set; }

        public int Sex { get; set; }

        public DateTime CreatedDate { get; set; }

        // Thuộc tính tên label
        public string LabelMessage { get; set; }
    }
}
