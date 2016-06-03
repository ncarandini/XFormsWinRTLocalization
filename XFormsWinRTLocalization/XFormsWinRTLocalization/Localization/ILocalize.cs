using System;
using System.Globalization;
using Windows.ApplicationModel.Resources;

namespace XFormsWinRTLocalization
{
	public interface ILocalize
	{
		void SetLocale();

		CultureInfo GetCurrentCultureInfo();

        // String GetString(string key);
    }
}

