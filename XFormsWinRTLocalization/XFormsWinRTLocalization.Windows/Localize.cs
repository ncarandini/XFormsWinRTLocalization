using System.Globalization;

[assembly: Xamarin.Forms.Dependency(typeof(XFormsWinRTLocalization.Windows.Localize))]

namespace XFormsWinRTLocalization.Windows
{
    class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            return CultureInfo.CurrentUICulture;
        }

        public void SetLocale()
        {
            // Not used on this platform;
        }
    }
}
