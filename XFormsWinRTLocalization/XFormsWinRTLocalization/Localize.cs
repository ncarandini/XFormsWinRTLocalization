using System;
using System.Reflection;
using System.Diagnostics;
using System.Resources;
using System.Threading;
using System.Globalization;
using Xamarin.Forms;

namespace XFormsWinRTLocalization
{
	public class Localize
	{
		static readonly CultureInfo cultureInfo;

		static Localize () 
		{
            cultureInfo = DependencyService.Get<ILocalize>().GetCurrentCultureInfo ();
		}

		public static string GetString(string key, string comment)
		{
			ResourceManager resourceManager = new ResourceManager ("XFormsWinRTLocalization.Strings.Resource", typeof(Localize).GetTypeInfo ().Assembly);

			string result = resourceManager.GetString (key, cultureInfo);

			return result; 
		}
	}
}

