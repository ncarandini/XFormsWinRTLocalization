using System.Globalization;

[assembly: Xamarin.Forms.Dependency(typeof(XFormsWinRTLocalization.UWP.Localize))]

namespace XFormsWinRTLocalization.UWP
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
