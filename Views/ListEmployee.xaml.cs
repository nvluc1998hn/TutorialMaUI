using TutorialMaUI.ViewModel;

namespace TutorialMaUI.Views;

public partial class ListEmployee : ContentPage
{
    public ListEmployee()
    {
        InitializeComponent();
        BindingContext = new ListEmployeeViewModel(this);

        MessagingCenter.Subscribe<object>(this, "ReloadData", (sender) =>
        {
            // Call a method to reload the data
            var dataViewModel = BindingContext as ListEmployeeViewModel;
            dataViewModel.GetListData(dataViewModel.Keyword);
        });
    }
}