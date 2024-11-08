using Common.Library.BaseClasses;
using TutorialMAUI.Entity.EntityClass;

namespace TutorialMaUI.ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        #region Private Variables
        private User? _UserObject = new();
        #endregion

        #region Public Properties
        public User? UserObject
        {
            get { return _UserObject; }
            set
            {
                _UserObject = value;
                RaisePropertyChanged(nameof(UserObject));
            }
        }
        #endregion
    }
}