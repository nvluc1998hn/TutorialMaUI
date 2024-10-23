using CommunityToolkit.Maui.Views;
using TutorialMaUI.Helper;
using TutorialMaUI.Valid;
using TutorialMaUI.ViewModel.Respond;

namespace TutorialMaUI.Views;

/// <summary>
/// Chi tiết nhân viên
/// </summary>
/// Author: lucnv
/// Created: 17/10/2024
/// 
public partial class EmployeeDetail : Popup
{
    StaffValid staffValid;
    private bool CheckPhoneEixsts = false;
    private readonly List<AdminStaffResponse> _adminStaffResponses;
    public EmployeeDetail(AdminStaffResponse? staffData, List<AdminStaffResponse> lsData)
    {
        InitializeComponent();
        if (staffData?.Id > 0)
        {
            staffData.LabelMessage = "Sửa nhân viên";
            staffValid = MapDataHelper.StaffMapToValid(staffData);
            if (!string.IsNullOrEmpty(staffValid.Image.Value))
            {
                var imageBytes = Convert.FromBase64String(staffValid.Image.Value);
                MemoryStream imageDecodeStream = new(imageBytes);
                imageAvata.Source = ImageSource.FromStream(() => imageDecodeStream);
            }
        }
        else
        {
            staffValid = new StaffValid();
            staffValid.StaffCode = RenderStaffCode(lsData?.Any() == true ? lsData.Count + 1 : 1);
            staffValid.LabelMessage = "Thêm nhân viên";
        }
        _adminStaffResponses = lsData;
        BindingContext = staffValid;
    }

    private async void OnSaveClick(object sender, EventArgs e)
    {
        if (staffValid.Validate() && !CheckPhoneEixsts)
        {
            var data = staffValid;
            var dataToDb = MapDataHelper.StaffMapToDb(data);

            var _adminStaffService = Application.Current.MainPage.Handler.MauiContext.Services.GetService<Service.Interface.IAdminStaffService>();

            // Sửa 
            if (data.Id > 0)
            {
                await _adminStaffService.UpdateData(dataToDb);

                ToastHelper.ShowNotificationToa("Sửa thành công !");


            }
            // Thêm
            else
            {
                await _adminStaffService.InsertData(dataToDb);

                ToastHelper.ShowNotificationToa("Thêm thành công !");
            }

            MessagingCenter.Send<object>(this, "ReloadData");

            this.Close();
        }
    }

    private void ClosePopup(object sender, EventArgs e)
    {
        this.Close();
    }

    private void ChangeStaffName(object sender, TextChangedEventArgs e)
    {
        if (e.OldTextValue != e.NewTextValue)
        {
            staffValid.StaffName.Validate();
        }
    }

    private string RenderStaffCode(int length)
    {
        return $"BAP{length:0000}";
    }

    private void ChangePhone(object sender, TextChangedEventArgs e)
    {
        if (e.OldTextValue != e.NewTextValue)
        {
            staffValid.Phone.Validate();

            CheckPhoneEixsts = false;

            if (_adminStaffResponses?.Count > 0 && !staffValid.Phone.HasErrors)
            {
                var inDex = _adminStaffResponses.FindIndex(c => c.Phone == staffValid.Phone.Value && c.Id != staffValid.Id);

                if (inDex > -1)
                {
                    staffValid.Phone.HasErrors = true;
                    staffValid.Phone.Error = "Số điện thoại đã tồn tại";
                    CheckPhoneEixsts = true;
                }
            }
        }
    }

    private void ChangeEmail(object sender, TextChangedEventArgs e)
    {
        if (e.OldTextValue != e.NewTextValue)
        {
            staffValid.Email.Validate();
        }
    }

    private void ChangeAddress(object sender, TextChangedEventArgs e)
    {
        if (e.OldTextValue != e.NewTextValue)
        {
            staffValid.Address.Validate();
        }
    }

    private async void OpenSelectImage(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Chọn hình ảnh"
            });

            if (result == null)
            {
                // Người dùng hủy chọn tệp
                return;
            }

            // Kiểm tra kích thước ảnh (tối đa 2MB)
            if (result.FullPath != null)
            {
                var fileInfo = new FileInfo(result.FullPath);
                if (fileInfo.Length > 2 * 1024 * 1024) // 2MB
                {
                    await Application.Current.MainPage.DisplayAlert("Lỗi", "Kích thước ảnh lớn hơn 2MB", "OK");
                    return;
                }
            }

            // Đọc tệp ảnh từ thiết bị
            var stream = await result.OpenReadAsync();

            using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);

            // Chuyển đổi thành Base64
            var imageBytes = memoryStream.ToArray();
            var base64Image = Convert.ToBase64String(imageBytes);

            // Gán Base64 vào thuộc tính Staff.Image
            staffValid.Image.Value = base64Image;

            memoryStream.Seek(0, SeekOrigin.Begin); // Reset position to the beginning of the stream
            imageAvata.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
        }
        catch (Exception ex)
        {
            // Xử lý lỗi (nếu có)
            await Application.Current.MainPage.DisplayAlert("Lỗi", $"Không thể chọn hình ảnh: {ex.Message}", "OK");
        }
    }
}