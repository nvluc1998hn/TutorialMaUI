using Plugin.ValidationRules.Interfaces;
using TutorialMaUI.Resources.Language;

namespace TutorialMaUI.Validations
{
    public class PasswordRule : IValidationRule<string>
    {
        public string ValidationMessage { get; set; }

        public bool Check(string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                if (value.Length > 50)
                {
                    ValidationMessage = String.Format(AppResources.MaxLength50, AppResources.PassWord);
                    return false;
                }
            }
            return true;
        }
    }
}
