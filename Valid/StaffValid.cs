using Plugin.ValidationRules;
using Plugin.ValidationRules.Extensions;
using System.Collections.ObjectModel;
using TutorialMaUI.Models;
using TutorialMaUI.Resources.Language;

namespace TutorialMaUI.Valid
{
    /// <summary>
    ///  Valid thông tin nhân viên
    /// </summary>
    /// Author: lucnv
    /// Created: 18/10/2024
    public class StaffValid
    {
        public int Id { get; set; }

        public Validatable<string> StaffName { get; set; } = new Validatable<string>();

        public Validatable<string> Address { get; set; } = new Validatable<string>();

        public Validatable<string> Phone { get; set; } = new Validatable<string>();

        public Validatable<string> Email { get; set; } = new Validatable<string>();

        public Validatable<string> Image { get; set; } = new Validatable<string>();

        public int Part { get; set; }

        public int Sex { get; set; }

        public string LabelMessage { get; set; }

        // Combox giới tính
        public ObservableCollection<Gender> GenderOptions { get; set; }

        // Combox chức vụ
        public ObservableCollection<Parts> PartsOptions { get; set; }


        public readonly IList<Gender> source;
        public readonly IList<Parts> part;


        public StaffValid()
        {
            source = new List<Gender>();
            part = new List<Parts>();
            CreateGenderCollection();
            CreatePartsOption();
            GenderOptions = new ObservableCollection<Gender>(source);
            PartsOptions = new ObservableCollection<Parts>(part);

            string passMessageValid = string.Format(AppResources.Required, AppResources.StaffName);
            string messageMaxLength = string.Format(AppResources.MaxLength50, AppResources.StaffName);
            string pattern = @"^[^'`~!@#$%^*()\-_+={}[\]:;|\\,.?]*$";

            StaffName = Validator.Build<string>().IsRequired(passMessageValid).WithMaxLengthStrRule(50, messageMaxLength).WithRegularExpression(pattern, AppResources.ForbiddenCharacters);

            string addressValid = string.Format(AppResources.Required, AppResources.Address);
            string addMessageMaxLength = string.Format(AppResources.MaxLength50, AppResources.Address);


            Address = Validator.Build<string>().IsRequired(addressValid).WithMaxLengthStrRule(50, addMessageMaxLength);

            string emailValid = string.Format(AppResources.Required, AppResources.Email);
            string emailMessageMaxLength = string.Format(AppResources.MaxLength50, AppResources.Email);

            Email = Validator.Build<string>().IsRequired(emailValid).WithMaxLengthStrRule(50, emailMessageMaxLength).IsEmail(AppResources.EmailValid);

            string phoneValid = string.Format(AppResources.Required, AppResources.Phone);

            Phone = Validator.Build<string>().IsRequired(phoneValid);

        }

        public bool Validate()
        {
            return StaffName.Validate() && Address.Validate() && Email.Validate() && Phone.Validate();
        }

        void CreateGenderCollection()
        {
            source.Add(new Gender { Id = 0, Name = "Nam" });
            source.Add(new Gender { Id = 1, Name = "Nữ" });
            source.Add(new Gender { Id = 2, Name = "Khác" });
        }

        void CreatePartsOption()
        {
            part.Add(new Parts { Id = 0, Name = "Nhân viên" });
            part.Add(new Parts { Id = 1, Name = "Trưởng phòng" });
            part.Add(new Parts { Id = 2, Name = "Giám đốc" });

        }
    }
}
