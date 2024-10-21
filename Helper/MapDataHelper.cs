using TutorialMaUI.Valid;
using TutorialMaUI.ViewModel.Respond;

namespace TutorialMaUI.Helper
{
    public class MapDataHelper
    {
        public static AdminStaffResponse StaffMapToDb(StaffValid staffValid)
        {
            AdminStaffResponse adminStaffViewModel = new AdminStaffResponse();
            adminStaffViewModel.Id = staffValid.Id;
            adminStaffViewModel.StaffName = staffValid.StaffName.Value;
            adminStaffViewModel.Address = staffValid.Address.Value;
            adminStaffViewModel.Phone = staffValid.Phone.Value;
            adminStaffViewModel.Email = staffValid.Email.Value;
            adminStaffViewModel.Image = staffValid.Image.Value;
            adminStaffViewModel.Part = staffValid.Part;
            adminStaffViewModel.Sex = staffValid.Sex;
            return adminStaffViewModel;
        }

        public static StaffValid StaffMapToValid(AdminStaffResponse adminStaffResponse)
        {
            StaffValid staffValid = new StaffValid();
            staffValid.Id = adminStaffResponse.Id;
            staffValid.StaffName.Value = adminStaffResponse.StaffName;
            staffValid.Address.Value = adminStaffResponse.Address;
            staffValid.Phone.Value = adminStaffResponse.Phone;
            staffValid.Email.Value = adminStaffResponse.Email;
            staffValid.Image.Value = adminStaffResponse.Image;
            staffValid.Sex = adminStaffResponse.Sex;
            staffValid.Part = adminStaffResponse.Part;
            staffValid.LabelMessage = adminStaffResponse.LabelMessage;
            return staffValid;
        }
    }
}
