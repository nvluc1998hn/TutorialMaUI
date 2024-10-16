using CommunityToolkit.Maui.Views;
using System.ComponentModel;

namespace TutorialMaUI.Pages;

public partial class PopupPage : Popup, INotifyPropertyChanged
{
    private string labelMessage;

    public string LabelMessage
    {
        get => labelMessage;
        set
        {
            labelMessage = value;
            OnPropertyChanged(nameof(LabelMessage)); // Notify the UI about the change
        }
    }

    public PopupPage(string label)
    {
        InitializeComponent();
        LabelMessage = label;
        BindingContext = this;
    }

    // Implement the INotifyPropertyChanged event
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void ClosePopup(object sender, EventArgs e)
    {

    }
}

