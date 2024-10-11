using Plugin.ValidationRules;
using Plugin.ValidationRules.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TutorialMaUI.Resources.Language;
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

        // Notify the UI of changes
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public UserLoginValid()
        {
            string passMessageValid = string.Format(AppResources.Required, AppResources.PassWord);
            string userNameMessageValid = string.Format(AppResources.Required, AppResources.UserName);

            UserName = Validator.Build<string>().IsRequired(userNameMessageValid).WithRule(new UserNameRule());
            PassWord = Validator.Build<string>().IsRequired(passMessageValid).WithRule(new PasswordRule());
        }

        public bool Validate()
        {
            return PassWord.Validate() && UserName.Validate();
        }
    }
}
