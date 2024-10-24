using Common.Library.LanguageKeys;
using LocalizationResourceManager.Maui.ComponentModel;
using Plugin.ValidationRules;
using Plugin.ValidationRules.Extensions;
using TutorialMaUI.Extensions;
using TutorialMaUI.Validations;

namespace TutorialMaUI.Valid
{
    /// <summary>
    /// Valid thông tin User
    /// </summary>
    /// Author: lucnv
    /// Created: 09/10/2024
    public class UserLoginValid : ObservableObject
    {
        public Validatable<string> UserName { get; set; }

        public Validatable<string> PassWord { get; set; }

        private bool _isEnableButtonSubmit;

        public bool IsEnableButtonSubmit
        {
            get => _isEnableButtonSubmit;
            set
            {
                SetProperty(ref _isEnableButtonSubmit, value);
            }
        }

        private bool _autoLogin;

        public bool AutoLogin
        {
            get => _autoLogin;
            set
            {
                SetProperty(ref _autoLogin, value);
            }
        }

        public UserLoginValid()
        {
            var required = Translator.Instance[LanguageKey.Required];
            string passMessageValid = string.Format(required, Translator.Instance[LanguageKey.PassWord]);
            string userNameMessageValid = string.Format(required, Translator.Instance[LanguageKey.UserName]);

            UserName = Validator.Build<string>().IsRequired(userNameMessageValid).WithRule(new UserNameRule());
            PassWord = Validator.Build<string>().IsRequired(passMessageValid).WithRule(new PasswordRule());

        }

        public bool Validate()
        {
            return PassWord.Validate() && UserName.Validate();
        }

    }
}
