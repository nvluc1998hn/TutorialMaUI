using TutorialMaUI.Enums;

namespace TutorialMaUI.ViewModel.Respond
{
    public class LoginViewModel
    {
        public LoginStatus Status { set; get; }

        public int CompanyId { set; get; }

        public int ParentCompanyID { get; set; }

        public Guid UserId { set; get; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string AccessToken { get; set; }

        public string FullName { get; set; }

        public List<int> Permissions { set; get; }
    }
}
