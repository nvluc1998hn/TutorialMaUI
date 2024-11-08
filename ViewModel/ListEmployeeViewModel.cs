using Common.Library.Helper;
using CommunityToolkit.Maui.Views;
using LocalizationResourceManager.Maui.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TutorialMaUI.Helper;
using TutorialMaUI.PopUp;
using TutorialMaUI.Service.Interface;
using TutorialMaUI.ViewModel.Respond;
using TutorialMaUI.Views;

namespace TutorialMaUI.ViewModel
{
    /// <summary>
    /// Thông tin nhân viên
    /// </summary>
    /// Author: lucnv
    /// Created: 19/10/2024
    public class ListEmployeeViewModel : ObservableObject
    {

        public List<AdminStaffResponse> listAll = new();


        public int _totalRecords = 100;  // Tổng số bản ghi
        public readonly int _itemsPerPage = 15;   // Số bản ghi 1 trang
        public int _currentPage = 0;     // Trang hiện tại

        public ICommand LoadMoreItemsCommand { get; private set; }
        public ICommand GetDetailDataCommand { get; private set; }
        public ICommand GetDetailDataOnRowCommand { get; private set; }

        public ICommand SaveDataCommand { get; private set; }
        public ICommand DeleteDataCommand { get; private set; }
        public ICommand GetDataByKeyWordCommand { get; private set; }
        public ICommand AddStaffCommand { get; private set; }



        private bool _isLoading = false;

        private ObservableCollection<AdminStaffResponse> _records;

        public ObservableCollection<AdminStaffResponse> Records
        {
            get => _records;
            set => SetProperty(ref _records, value);
        }

        private string _keyword;

        public string Keyword
        {
            get => _keyword;
            set => SetProperty(ref _keyword, value);
        }

        private readonly Page _page;

        public ListEmployeeViewModel(Page page)
        {
            _page = page;
            Task.Run(async () => await GetListData(Keyword));
            LoadMoreItemsCommand = new Command<object>((obj) => LoadMoreItems());
            GetDetailDataCommand = new Command<object>((obj) => GetDetailData(obj));
            GetDetailDataOnRowCommand = new Command<object>((obj) => GetDetailData(obj));
            DeleteDataCommand = new Command<object>((obj) => DeleteData(obj));
            AddStaffCommand = new Command(() => AddStaff());
            GetDataByKeyWordCommand = new Command(async () => await GetListData(Keyword));
        }

        public void GetDetailData(object obj)
        {
            try
            {
                if (obj != null)
                {
                    var selected = new AdminStaffResponse();

                    if (obj is AdminStaffResponse)
                    {
                        selected = (AdminStaffResponse)obj;
                    }
                    else
                    {
                        var dataItem = obj.GetType().GetProperty("DataItem")?.GetValue(obj);
                        selected = (AdminStaffResponse)dataItem;
                    }
                    var popup = new EmployeeDetail(selected, listAll);
                    _page.ShowPopup(popup);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning(ex.Message);
            }

        }

        public void AddStaff()
        {
            var popup = new EmployeeDetail(null, listAll);
            _page.ShowPopup(popup);
        }

        public async void DeleteData(object obj)
        {
            if (obj is AdminStaffResponse data)
            {
                var textNotifi = $"Bạn có chắc chắn muốn xóa lái xe {data.StaffName} ?";
                var popup = new PopupConfirm(textNotifi);
                _page.ShowPopup(popup);

                popup.Accepted += async (s, args) =>
                {
                    var _adminStaffService = Application.Current.MainPage.Handler.MauiContext.Services.GetService<IAdminStaffService>();

                    if (_adminStaffService != null)
                    {
                        bool isDeleteSuccess = await _adminStaffService.DeleteData(data.Id);

                        if (isDeleteSuccess)
                        {
                            ToastHelper.ShowNotificationToa("Xóa thành công !");

                            Records.Remove(data);
                            listAll.Remove(data);
                        }
                    }
                };
            }
        }

        public void LoadMoreItems()
        {
            if (_isLoading || Records.Count >= _totalRecords) return; // Stop if all records are loaded

            _isLoading = true;

            try
            {
                // Fetch the next page of data
                var newRecords = listAll.Skip((_currentPage + 1) * _itemsPerPage).Take(_itemsPerPage).ToList();

                if (newRecords?.Any() == true)
                {
                    foreach (var record in newRecords)
                    {
                        Records.Add(record);  // Add new records to the existing list
                    }

                    _currentPage++; // Move to the next page
                }

                // Stop loading if less than 15 records are returned (means all data is loaded)
                if (newRecords?.Count < _itemsPerPage)
                {
                    _totalRecords = Records.Count; // Assume this is the final total count
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning(ex.Message);
            }
            finally
            {
                _isLoading = false;
            }
        }

        public async Task<ObservableCollection<AdminStaffResponse>> GetListData(string keyword)
        {
            ObservableCollection<AdminStaffResponse> result = new();
            try
            {
                _currentPage = 0;
                var _adminStaffService = Application.Current?.MainPage?.Handler?.MauiContext?.Services.GetService<IAdminStaffService>();
                if (_adminStaffService != null)
                {
                    listAll = await _adminStaffService.GetListStaffByCondition(keyword);
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        var dataByKeyWord = listAll.Where(c => c.StaffName.ToLower().Contains(keyword.ToLower()));
                        _totalRecords = dataByKeyWord.Count();
                        result = new ObservableCollection<AdminStaffResponse>(dataByKeyWord.Take(_itemsPerPage));
                    }
                    else
                    {
                        _totalRecords = listAll.Count;
                        result = new ObservableCollection<AdminStaffResponse>(listAll.Take(_itemsPerPage));
                    }

                    Records = result;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Warning(ex.Message);
            }
            return result;
        }
    }
}
