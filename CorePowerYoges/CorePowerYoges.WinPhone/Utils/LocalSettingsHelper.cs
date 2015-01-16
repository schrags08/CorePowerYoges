using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CorePowerYoges.WinPhone.Utils
{
    // not sure i need or want this, seems kind of dumb at the moment...
    public static class LocalSettingsHelper
    {
        static ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public static void AddSetting(string settingName, string setting)
        {
            localSettings.Values[settingName] = setting;
        }

        public static string GetSetting(string settingName)
        {
            var setting = localSettings.Values[settingName] as string;
            return setting;
        }

        public static void RemoveSetting(string settingName)
        {
            localSettings.Values.Remove(settingName);
        }
    }

    //public class Settings
    //{
    //    public List<string> FavoriteLocations { get; set; }
    //}
}
