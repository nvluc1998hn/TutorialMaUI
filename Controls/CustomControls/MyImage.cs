using CommunityToolkit.Maui.Behaviors;

namespace TutorialMaUI.Controls.CustomControls
{
    public class MyImage : Image
    {
        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }

        public static readonly BindableProperty TintColorProperty = BindableProperty.Create(
        nameof(TintColor), typeof(Color), typeof(MyImage), null, BindingMode.TwoWay, propertyChanged: OnTintColorPropertyChanged);

        private static void OnTintColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MyImage)bindable;
            control.Behaviors.Add(new IconTintColorBehavior { TintColor = (Color)newValue });
        }
    }
}
