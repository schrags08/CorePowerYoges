using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources.Core;

namespace CorePowerYoges.Phone.Utils
{
    public static class ResourcesHelper
    {
        private static ResourceMap _mainResourceMap = ResourceManager.Current.MainResourceMap;
        private static ResourceContext _resourceContext = ResourceContext.GetForCurrentView();

        public static string GetValue(string key, string prefix = "Resources")
        {
            string keyFormat = "{0}/{1}";

            var resource = _mainResourceMap.GetValue(string.Format(keyFormat, prefix, key), _resourceContext);
            if (resource != null)
            {
                return resource.ValueAsString;
            }

            return string.Empty;
        }
    }
}
