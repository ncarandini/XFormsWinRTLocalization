using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using XFormsWinRTLocalization.PagesCs;
using XFormsWinRTLocalization.PagesXaml;
using XFormsWinRTLocalization.Strings;

namespace XFormsWinRTLocalization
{
    public class App : Application
    {
        public App()
        {
            System.Diagnostics.Debug.WriteLine("===============");
            var assembly = typeof(App).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
            {
                System.Diagnostics.Debug.WriteLine("found resource: " + res);
            }

            if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
            {
                DependencyService.Get<ILocalize>().SetLocale();
                AppResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            }

            var tabs = new TabbedPage();

            tabs.Children.Add(new FirstPage { Title = "C#", Icon = "csharp.png" });

            tabs.Children.Add(new FirstPageXaml { Title = "Xaml", Icon = "xaml.png" });

            MainPage = tabs;
        }
    }
}
