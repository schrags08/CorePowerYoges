using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.ApplicationModel.Resources.Core;

namespace CorePowerYoges.WinPhone.Utils
{
    public static class AppResourcesHelper
    {
        private static ResourceMap _mainResourceMap = ResourceManager.Current.MainResourceMap;
        private static ResourceContext _resourceContext = ResourceContext.GetForCurrentView();

        public static string GetValue(string key)
        {
            string keyFormat = "AppResources/{0}";

            var resource = _mainResourceMap.GetValue(string.Format(keyFormat, key), _resourceContext);
            if (resource != null)
            {
                return resource.ValueAsString;
            }

            return string.Empty;
        }
    }
}
