using TutorialMaUI.ViewModel;

namespace TutorialMaUI.Views;

/// <summary>
/// Danh sách nhân viên
/// </summary>
/// Author: lucnv
/// Created: 08/11/2024
/// Modified: date - user - description
public partial class ListEmployee : ContentPage
{
    public ListEmployee()
    {
        InitializeComponent();
        BindingContext = new ListEmployeeViewModel(this);

        // Sự kiện lắng nghe khi thêm mới dữ liệu
        MessagingCenter.Subscribe<object>(this, "ReloadData", (sender) =>
        {
            // Call a method to reload the data
            var dataViewModel = BindingContext as ListEmployeeViewModel;
            dataViewModel.GetListData(dataViewModel.Keyword);
        });
    }
}