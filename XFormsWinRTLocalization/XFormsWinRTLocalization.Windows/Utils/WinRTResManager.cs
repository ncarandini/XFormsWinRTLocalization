using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace XFormsWinRTLocalization.Windows.Utils
{
    // see: https://blogs.msdn.microsoft.com/philliphoff/2014/11/19/missingmanifestresourceexception-when-using-portable-class-libraries-within-winrt
    public class WinRTResourceManager : ResourceManager
    {
        private ResourceLoader resourceLoader;

        private WinRTResourceManager(string baseName, Assembly assembly) : base(baseName, assembly)
        {
            resourceLoader = ResourceLoader.GetForViewIndependentUse(baseName);
        }

        public static void InjectIntoResxGeneratedApplicationResourcesClass(Type resxGeneratedApplicationResourcesClass)
        {
            resxGeneratedApplicationResourcesClass
                .GetRuntimeFields()
                .First(m => m.Name == "resourceMan")
                .SetValue(null, new WinRTResourceManager(
                    resxGeneratedApplicationResourcesClass.FullName,
                    resxGeneratedApplicationResourcesClass.GetTypeInfo().Assembly));
        }

        public override string GetString(string name, CultureInfo culture)
        {
            return resourceLoader.GetString(name);
        }
    }
}
