using Common.Library.Helper;
using Common.Library.RestAPI;
using TutorialMaUI.ModelApi.CrossUrl;
using TutorialMaUI.ModelApi.Request;
using TutorialMaUI.ModelApi.Respond;
using TutorialMaUI.Resources.Language;
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
             { 0, AppResources.Staff },
             { 1, AppResources.HeadOfDepartment },
             { 2, AppResources.Manager }
        };

        public AdminStaffService(IServiceCommunication serviceCommunication)
        {
            _serviceCommunication = serviceCommunication;
        }

        // Fake data từ API V3 lấy danh sách lộ trình vẽ demo polyline tí 
        public async Task<RouteDataViewModel> GetListRoute(string fromDate, string toDate)
        {
            var result = new RouteDataViewModel();
            try
            {
                string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI4ZjAzZWRlNi01OGVjLTRhYTMtODc4OS1iNTZjYmZmOGI5Y2EiLCJpYXQiOiIxNzMwODI1OTkzNzE5Iiwic3ViIjoiYmYwODNmZGQtZDQ2YS00MzVkLWEzOTQtMWI3YjQxOTBiOTgyIiwiWG5Db2RlIjoiOTUwIiwiQ3VzdG9tZXJDb2RlIjoiIiwiTG9naW5Vc2VySWQiOiJlNjZlMzAwZS1iNjQ0LTQxYjAtODEyNC1jZTk5NTQ0MzRjNmYiLCJleHAiOjE3MzA4MTUxOTMsImlzcyI6IjE5Mi4xNjguNDUuNDgifQ.GqI8iPIQ7Prj0TnMNx2CPMuGVS9TU8h8iJPBjmwnT_g";

                var vehicleData = new VehicleData
                {
                    StartTime = DateTime.Parse(fromDate),
                    EndTime = DateTime.Parse(toDate),
                    VehicleId = 442323,
                    VehiclePlate = "43C01338_C",
                    IsEnableAcc = false,
                    GetAddress = true,
                    LimitSpeedByPNC = true,
                    LimitByGeocoding = true,
                    SpeedAllow = 60,
                    UseSpeakerSoundModule = false,
                    ViewDriverInfo = true,
                    VehicleConfigs = new VehicleConfigs
                    {
                        VMin = 11,
                        MaxVelocityBlue = 80,
                        MaxVelocityRed = 100,
                        MinuteStopLongTime = 150,
                        TimeLossGSM = 150,
                        MinTimeLossGPS = 5,
                        MaxTimeLossGPS = 150
                    }
                };
                result = await _serviceCommunication.PostAsync<RouteDataViewModel>("AdminStaffService", CrossUrlLink.UrlRouteV3, vehicleData, token);
            }
            catch (Exception ex)
            {
                LogHelper.Warning($"{GetType().Name} {ex.Message}");
            }
            return result;
        }

        public async Task<List<AdminStaffResponse>> GetListStaffByCondition(string condition)
        {
            var result = new List<AdminStaffResponse>();
            try
            {

                var dataBody = new
                {
                    keyword = condition,
                };

                result = await _serviceCommunication.PostAsync<List<AdminStaffResponse>>("AdminStaffService", CrossUrlLink.AdminStaffList, dataBody);

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

                isSuccess = await _serviceCommunication.PostAsync<bool>("AdminStaffService", CrossUrlLink.AdminStaffInsert, dataInsert);
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
                isSuccess = await _serviceCommunication.PostAsync<bool>("AdminStaffService", CrossUrlLink.AdminStaffUpdate, dataUpdate);
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
                await _serviceCommunication.GetAsync<bool>("AdminStaffService", CrossUrlLink.AdminStaffDelete, [StaffId]);

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
