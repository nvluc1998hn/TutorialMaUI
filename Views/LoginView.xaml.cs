using LocalizationResourceManager.Maui.ComponentModel;
using System.Windows.Input;
using TutorialMaUI.Valid;
using TutorialMaUI.ViewModel;

namespace TutorialMaUI.Views;

public partial class LoginView : ContentPage
{
    UserLoginValid _userLoginValid;

    public LoginView()
    {

        InitializeComponent();
        _userLoginValid = new UserLoginValid();
        BindingContext = _userLoginValid;
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        var isValid = _userLoginValid.Validate();
        System.Diagnostics.Debugger.Break();
    }

    private void ChangeInputUserName(object sender, TextChangedEventArgs e)
    {
        if (e.OldTextValue != e.NewTextValue)
        {
            _userLoginValid.UserName.Validate();
            _userLoginValid.IsEnableButtonSubmit = !_userLoginValid.UserName.HasErrors && (!_userLoginValid.PassWord.HasErrors && !string.IsNullOrEmpty(_userLoginValid.PassWord.Value));
        }
    }
    private void ChangeInputPass(object sender, TextChangedEventArgs e)
    {
        if (e.OldTextValue != e.NewTextValue)
        {
            _userLoginValid.PassWord.Validate();
            _userLoginValid.IsEnableButtonSubmit = !_userLoginValid.UserName.HasErrors && !_userLoginValid.PassWord.HasErrors;
        }
    }
}