using CommunityToolkit.Maui.Views;

namespace TutorialMaUI.PopUp;

public partial class DetailImagePopup : Popup
{
    public string ImageUrl { get; set; }
    public DetailImagePopup(string imageBase64)
    {
        InitializeComponent();

        if (!string.IsNullOrEmpty(imageBase64))
        {
            var imageBytes = Convert.FromBase64String(imageBase64);
            MemoryStream imageDecodeStream = new(imageBytes);
            imageAvata.Source = ImageSource.FromStream(() => imageDecodeStream);
        }
    }

    private void OnCloseButtonClicked(object sender, EventArgs e)
    {
        this.Close();
    }
}

