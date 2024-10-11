using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TutorialMaUI.ViewModel;

namespace TutorialMaUI.CommandClass
{
    /// <summary>
    /// Thông tin đăng nhập của người dùng
    /// </summary>
    /// Author: lucnv
    /// Created: 09/10/2024
    public class UserViewModelCommands : UserViewModel
    {
        #region Public Properties
       
        #endregion

        #region Commands
        public ICommand SaveCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        #endregion

        #region Init Method
        public override void Init()
        {
            base.Init();

            // Create commands for this view
            SaveCommand = new Command(async () => await SaveAsync());
        }
        #endregion

        public async Task<bool> SaveAsync()
        {
            return true;
        }
    }
}
