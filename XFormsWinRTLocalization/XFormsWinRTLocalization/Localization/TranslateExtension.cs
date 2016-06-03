using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using System.Resources;
using System.Globalization;
using System.Reflection;
using XFormsWinRTLocalization.Strings;
using System.Linq;

namespace XFormsWinRTLocalization
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo cultureInfo;
        readonly ResourceManager resmgr;

        const string ResourceId = "XFormsWinRTLocalization.Strings.AppResources";

        public TranslateExtension()
        {
            cultureInfo = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

            resmgr = typeof(AppResources)
                .GetRuntimeFields()
                .First(m => m.Name == "resourceMan")
                .GetValue(typeof(AppResources)) as ResourceManager;
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return String.Empty;

            var translation = resmgr.GetString(Text, cultureInfo);

            if (translation == null)
            {
                #if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, cultureInfo.Name),
                    "Text");
                #else
				translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
                #endif
            }
            return translation;
        }
    }
}