using CommunityToolkit.Maui.Views;
using System.ComponentModel;

namespace TutorialMaUI.PopUp;

public partial class PopupConfirm : Popup, INotifyPropertyChanged
{
    private string labelMessage;
    public event EventHandler Accepted;

    public string LabelMessage
    {
        get => labelMessage;
        set
        {
            labelMessage = value;
            OnPropertyChanged(nameof(LabelMessage)); // Notify the UI about the change
        }
    }

    public PopupConfirm(string label)
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
        this.Close();
    }

    private void AcceptPopup(object sender, EventArgs e)
    {
        Accepted?.Invoke(this, EventArgs.Empty);
        Close();
    }
}