using System.Globalization;

[assembly: Xamarin.Forms.Dependency(typeof(XFormsWinRTLocalization.WinPhone.Localize))]

namespace XFormsWinRTLocalization.WinPhone
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
