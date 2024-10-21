using Common.Library.BaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TutorialMaUI.Valid;
using TutorialMAUI.Entity.EntityClass;

namespace TutorialMaUI.ViewModel
{
    public class UserViewModel: ViewModelBase
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