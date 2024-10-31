namespace TutorialMaUI.Views.Map;

public partial class BindingPinView2 : Grid
{
    private string _display;
    private string _imageUrl;

    public BindingPinView2(string display, string imageUrl)
    {
        InitializeComponent();
        _display = display;
        _imageUrl = imageUrl;
        BindingContext = this;
    }
    public string Display
    {
        get { return _display; }
    }

    public string ImageUrl
    {
        get { return _imageUrl; }
    }
}