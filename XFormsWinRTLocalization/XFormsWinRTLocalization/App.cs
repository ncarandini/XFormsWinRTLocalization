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
                System.Diagnostics.Debug.WriteLine("found resource: " + res);


            if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS)
            {
                DependencyService.Get<ILocalize>().SetLocale();
                AppResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            }

            if (Device.OS == TargetPlatform.Windows)
            {
                // Solve the "System.Resources.MissingManifestResourceException"
                // using the trick shown here: https://blogs.msdn.microsoft.com/philliphoff/2014/11/19/missingmanifestresourceexception-when-using-portable-class-libraries-within-winrt/

                // WinRTResManager.InjectIntoResxGeneratedApplicationResourcesClass(typeof(AppResources));

                //typeof(AppResources).GetRuntimeFields()
                //.First(m => m.Name == "resourceMan")
                //.SetValue(null, new ResManager(typeof(AppResources).FullName, typeof(AppResources).GetTypeInfo().Assembly));

            }

            var tabs = new TabbedPage();

            tabs.Children.Add(new FirstPage { Title = "C#", Icon = "csharp.png" });

            tabs.Children.Add(new FirstPageXaml { Title = "Xaml", Icon = "xaml.png" });

            MainPage = tabs;
        }
    }
}
