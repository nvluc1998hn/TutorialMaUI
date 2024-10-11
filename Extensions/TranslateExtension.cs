using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TutorialMaUI.Resources.Language;

namespace TutorialMaUI.Extensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        private readonly CultureInfo _ci;

        static readonly Lazy<ResourceManager> ResMgr = new Lazy<ResourceManager>(
            () => new ResourceManager(typeof(AppResources).FullName, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public string Text { get; set; }
        public object[] FormatParameters { get; set; }

        public TranslateExtension()
        {
            _ci = new CultureInfo("vi-VN"); // Default to Vietnamese
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            // Check if FormatParameters is provided
            var parameters = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (parameters != null)
            {
                var formatParameters = parameters.TargetObject.GetType().GetProperty("FormatParameters")?.GetValue(parameters.TargetObject);
                if (formatParameters != null)
                {
                    return string.Format(ResMgr.Value.GetString(Text, _ci) ?? Text, formatParameters);
                }
            }

            return ResMgr.Value.GetString(Text, _ci) ?? Text;

        }
    }


}
