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

    public EmployeeDetail(AdminStaffResponse? staffData)
    {
        InitializeComponent();
        if (staffData?.Id > 0)
        {
            staffData.LabelMessage = "Sửa nhân viên";
            staffValid = MapDataHelper.StaffMapToValid(staffData);
        }
        else
        {
            staffValid = new StaffValid();
            staffValid.LabelMessage = "Thêm nhân viên";
        }

        BindingContext = staffValid;
    }

    private async void OnSaveClick(object sender, EventArgs e)
    {
        if (staffValid.Validate())
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

    private void ChangePhone(object sender, TextChangedEventArgs e)
    {
        if (e.OldTextValue != e.NewTextValue)
        {
            staffValid.Phone.Validate();
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


}