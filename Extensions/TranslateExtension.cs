namespace TutorialMaUI.Extensions
{
    public class TranslateExtension : IMarkupExtension
    {
        public string Key { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding()
            {
                Mode = BindingMode.OneWay,
                Path = $"[{Key}]",
                Source = Translator.Instance,
            };
            return binding;
        }
    }


    //[ContentProperty("Text")]
    //public class TranslateExtension : IMarkupExtension
    //{
    //    private readonly CultureInfo _ci;

    //    static readonly Lazy<ResourceManager> ResMgr = new Lazy<ResourceManager>(
    //        () => new ResourceManager(typeof(AppResources).FullName, typeof(TranslateExtension).GetTypeInfo().Assembly));

    //    public string Text { get; set; }
    //    public object[] FormatParameters { get; set; }

    //    public TranslateExtension()
    //    {
    //        _ci = new CultureInfo("vi-VN"); // Default to Vietnamese
    //    }

    //    public object ProvideValue(IServiceProvider serviceProvider)
    //    {
    //        // Check if FormatParameters is provided
    //        var parameters = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
    //        if (parameters != null)
    //        {
    //            var formatParameters = parameters.TargetObject.GetType().GetProperty("FormatParameters")?.GetValue(parameters.TargetObject);
    //            if (formatParameters != null)
    //            {
    //                return string.Format(ResMgr.Value.GetString(Text, _ci) ?? Text, formatParameters);
    //            }
    //        }

    //        return ResMgr.Value.GetString(Text, _ci) ?? Text;

    //    }
    //}


}
