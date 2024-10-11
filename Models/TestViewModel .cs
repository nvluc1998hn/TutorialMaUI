using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialMaUI.Models
{
    public class TestViewModel : INotifyPropertyChanged
    {
        private bool _isEnableButton;

        public bool IsEnableButton
        {
            get => _isEnableButton;
            set
            {
                if (_isEnableButton != value)
                {
                    _isEnableButton = value;
                    OnPropertyChanged(nameof(IsEnableButton));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
