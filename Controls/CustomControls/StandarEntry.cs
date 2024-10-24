namespace TutorialMaUI.Controls.CustomControls
{
    public class StandarEntry : Entry
    {
        public StandarEntry()
        {
        }

        // Optionally, add a property for BorderColor
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            nameof(BorderColor), typeof(Color), typeof(StandarEntry), Colors.Red);

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public static readonly BindableProperty NoUnderlineProperty =
         BindableProperty.Create(
        nameof(NoUnderline),
        typeof(bool),
        typeof(StandarEntry));

        public bool NoUnderline
        {
            get => (bool)GetValue(NoUnderlineProperty);
            set => SetValue(NoUnderlineProperty, value);
        }



    }
}
