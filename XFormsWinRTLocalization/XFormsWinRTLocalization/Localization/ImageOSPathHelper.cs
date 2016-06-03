using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFormsWinRTLocalization
{
    public static class ImageOSPathHelper
    {
        public static string FilePath(string fileName)
        {
            switch (Device.OS)
            {
                case TargetPlatform.Other:
                    return fileName;
                case TargetPlatform.iOS:
                    return fileName;
                case TargetPlatform.Android:
                    return fileName;
                case TargetPlatform.WinPhone:
                    return fileName;
                case TargetPlatform.Windows:
                    return $"Assets/Images/{fileName}";
                default:
                    return fileName;
            }
        }

    }
}
