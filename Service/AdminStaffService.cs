using Common.Library.Helper;
using Common.Library.RestAPI;
using TutorialMaUI.Service.Interface;
using TutorialMaUI.ViewModel.Respond;

namespace TutorialMaUI.Service
{
    /// <summary>
    /// Service Nhân viên
    /// </summary>
    /// Author: lucnv
    /// Created: 18/10/2024
    public class AdminStaffService : IAdminStaffService
    {
        private IServiceCommunication _serviceCommunication;
        private static Dictionary<int, string> DicPart = new Dictionary<int, string>()
        {
             { 0, "Nhân viên" },
             { 1, "Trưởng phòng" },
             { 2, "Giám đốc" }
        };

        public AdminStaffService(IServiceCommunication serviceCommunication)
        {
            _serviceCommunication = serviceCommunication;
        }



        public async Task<List<AdminStaffResponse>> GetListStaffByCondition(string condition)
        {
            var result = new List<AdminStaffResponse>();
            try
            {
                var url = "http://10.1.11.107:8069/admin-staff/getlist";

                var dataBody = new
                {
                    keyword = condition,
                };

                result = await _serviceCommunication.PostAsync<List<AdminStaffResponse>>("AdminStaffService", url, dataBody);

                if (result?.Count > 0)
                {
                    foreach (var item in result)
                    {
                        if (DicPart.TryGetValue(item.Part, out string value))
                        {
                            item.PartName = value;
                        }
                    }
                    result = result.OrderByDescending(c => c.Part).ToList();

                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"{GetType().Name} {ex.Message}");
            }
            return result;
        }

        public async Task<bool> InsertData(AdminStaffResponse dataInsert)
        {
            bool isSuccess = false;
            try
            {
                var url = "http://10.1.11.107:8069/admin-staff/insert";

                isSuccess = await _serviceCommunication.PostAsync<bool>("AdminStaffService", url, dataInsert);
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"{GetType().Name} {ex.Message}");
            }
            return isSuccess;
        }

        public async Task<bool> UpdateData(AdminStaffResponse dataUpdate)
        {
            bool isSuccess = false;
            try
            {
                var url = "http://10.1.11.107:8069/admin-staff/update";

                isSuccess = await _serviceCommunication.PostAsync<bool>("AdminStaffService", url, dataUpdate);
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"{GetType().Name} {ex.Message}");
            }
            return isSuccess;
        }

        public async Task<bool> DeleteData(int StaffId)
        {
            bool isSuccess = false;
            try
            {
                var url = $"http://10.1.11.107:8069/admin-staff/staffId/{StaffId}";

                await _serviceCommunication.GetAsync<bool>("AdminStaffService", url);

                isSuccess = true;
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"{GetType().Name} {ex.Message}");
            }
            return isSuccess;
        }
    }
}
