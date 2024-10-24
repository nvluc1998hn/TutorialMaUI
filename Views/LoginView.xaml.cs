using Common.Library.LanguageKeys;
using Common.Library.RestAPI;
using CommunityToolkit.Maui.Views;
using System.Globalization;
using TutorialMaUI.Enums;
using TutorialMaUI.Extensions;
using TutorialMaUI.Models;
using TutorialMaUI.Pages;
using TutorialMaUI.Service;
using TutorialMaUI.Valid;
using TutorialMaUI.ViewModel.Respond;

namespace TutorialMaUI.Views;

public partial class LoginView : ContentPage
{
    UserLoginValid _userLoginValid;
    private bool isPasswordHidden = true;
    private IServiceCommunication _serviceCommunication;


    public LoginView(IServiceCommunication serviceCommunication)
    {
        InitializeComponent();
        _userLoginValid = new UserLoginValid();
        bool autoLogin = Preferences.Get(nameof(PreferencesEnum.AutoLogin), false);
        if (autoLogin)
        {
            string userName = Preferences.Default.Get(nameof(PreferencesEnum.UserName), "Unknown");
            string passWord = Preferences.Default.Get(nameof(PreferencesEnum.PassWord), "Unknown");
            _userLoginValid.UserName.Value = userName;
            _userLoginValid.PassWord.Value = passWord;
            _userLoginValid.AutoLogin = true;
        }
        BindingContext = _userLoginValid;
        labelLangueControl.Text = "Việt Nam";
        _serviceCommunication = serviceCommunication;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        var isValid = _userLoginValid.Validate();
        bool isLoginSuccess = false;
        string messageError = "";

        string apiUrl = "http://10.1.11.107:8069/authentication/login";
        try
        {
            if (isValid)
            {
                var loginData = new
                {
                    userName = _userLoginValid.UserName.Value,
                    password = _userLoginValid.PassWord.Value
                };

                var dataResult = await _serviceCommunication.PostAsync<LoginViewModel>(apiUrl, apiUrl, loginData);

                if (dataResult.Status == LoginStatus.Success)
                {
                    isLoginSuccess = true;
                    var service = Singleton<CommonService>.Instance;

                    // Set thông tin 
                    if (_userLoginValid.AutoLogin)
                    {
                        Preferences.Default.Set(nameof(PreferencesEnum.UserName), _userLoginValid.UserName.Value);
                        Preferences.Default.Set(nameof(PreferencesEnum.PassWord), _userLoginValid.PassWord.Value);
                        Preferences.Default.Set(nameof(PreferencesEnum.AutoLogin), true);
                    }
                    else
                    {
                        Preferences.Default.Remove(nameof(PreferencesEnum.UserName));
                        Preferences.Default.Remove(nameof(PreferencesEnum.PassWord));
                        Preferences.Default.Remove(nameof(PreferencesEnum.AutoLogin));
                    }

                    service.InfoUser = dataResult;
                    App.Current.MainPage = new NavigationPage(new TabbedPageTest());
                    await Navigation.PushAsync(new TabbedPageTest());
                }
                else if (dataResult.Status == LoginStatus.AccountDelete)
                {
                    messageError = Translator.Instance[LanguageKey.AccountDelete];
                }
                else if (dataResult.Status == LoginStatus.AccountLock)
                {
                    messageError = Translator.Instance[LanguageKey.AccountLock];
                }
                else
                {
                    messageError = Translator.Instance[LanguageKey.LoginFalse];
                }

                if (!isLoginSuccess)
                {
                    this.ShowPopup(new PopupPage(messageError));
                }
            }
        }
        catch (Exception ex)
        {
            // Handle error, e.g., show error message
            Console.WriteLine("Login failed: " + ex.Message);
        }
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

    private void OnImageTapped(object sender, EventArgs e)
    {
        if (isPasswordHidden)
        {
            txtPass.IsPassword = false;
            ImagePass.Source = "eyeshow.png";
        }
        else
        {
            txtPass.IsPassword = true;
            ImagePass.Source = "eyeslash.png";
        }

        isPasswordHidden = !isPasswordHidden;
    }

    private void ChangeLangue(object sender, EventArgs e)
    {
        var popup = new PopupLangue();
        // Sự kiện lắng nghe khi PopUp được chọn
        popup.ItemSelected += OnItemSelected;
        this.ShowPopup(popup);
    }

    private void OnItemSelected(Country selectedValue)
    {
        labelLangueControl.Text = selectedValue.CountryName;
        imageLangueControl.Source = selectedValue.FlagUrl;

        Translator.Instance.CultureInfo = new CultureInfo(selectedValue.IsoCode);
        Translator.Instance.OnPropetyChanged();
    }

    private void AutoLoginClick(object sender, TappedEventArgs e)
    {
        _userLoginValid.AutoLogin = !_userLoginValid.AutoLogin;

    }
}