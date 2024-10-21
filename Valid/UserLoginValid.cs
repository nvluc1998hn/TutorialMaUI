using Common.Library.LanguageKeys;
using Plugin.ValidationRules;
using Plugin.ValidationRules.Extensions;
using System.ComponentModel;
using TutorialMaUI.Extensions;
using TutorialMaUI.Validations;

namespace TutorialMaUI.Valid
{
    /// <summary>
    /// Valid thông tin User
    /// </summary>
    /// Author: lucnv
    /// Created: 09/10/2024
    public class UserLoginValid : INotifyPropertyChanged
    {
        public Validatable<string> UserName { get; set; }

        public Validatable<string> PassWord { get; set; }

        private bool _isEnableButtonSubmit;

        public bool IsEnableButtonSubmit
        {
            get => _isEnableButtonSubmit;
            set
            {
                _isEnableButtonSubmit = value;
                OnPropertyChanged(nameof(IsEnableButtonSubmit));  // Ensure this is triggered
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

        // Notify the UI of changes
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
