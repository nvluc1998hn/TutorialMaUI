using TutorialMaUI.ModelApi.Respond;
using TutorialMaUI.ViewModel.Respond;

namespace TutorialMaUI.Service.Interface
{
    public interface IAdminStaffService
    {
        Task<List<AdminStaffResponse>> GetListStaffByCondition(string condition);

        Task<bool> InsertData(AdminStaffResponse dataInsert);

        Task<bool> UpdateData(AdminStaffResponse dataUpdate);

        Task<bool> DeleteData(int StaffId);

        Task<RouteDataViewModel> GetListRoute(string fromDate, string toDate);

    }
}
