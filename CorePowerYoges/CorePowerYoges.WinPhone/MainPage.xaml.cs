using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using Windows.Storage;
using CorePowerYoges.WinPhone.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CorePowerYoges.Models;
using System.Collections.ObjectModel;
using CorePowerYoges.WinPhone.Repository;
using Newtonsoft.Json.Converters;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace CorePowerYoges.WinPhone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            //this.txtInput.Text = "{ 'settings': { 'favoriteLocations': [ '864_16', '864_15', '864_17', '864_7', '110_6', '110_5'] } }";

            this.txtInput.Text = AppResourcesHelper.GetValue("SampleFavorites");

            LocalSettingsHelper.AddSetting("userData", txtInput.Text);

            var favorites = await LoadFavorites();
        }       

        public async Task<ObservableCollection<State2>> LoadAllStates2()
        {
            IState2Repository repository = new State2Repository();
            return await repository.GetAllStatesAsync();
        }
        
        public async Task<DailySchedule2> LoadDailyScheduleByStateIdAndLocationId(DateTime date, string stateId, string locationId)
        {
            IDailySchedule2Repository repository = new DailySchedule2Repository();
            return await repository.GetDailyScheduleByStateIdAndLocationIdAsync(date, stateId, locationId);
        }

        private async Task<Dictionary<State2, List<Location2>>> LoadFavorites()
        {
            var allStates = await LoadAllStates2();
            var userData = JObject.Parse(LocalSettingsHelper.GetSetting("userData"));
            var favorites = new Dictionary<State2, List<Location2>>();

            var states = (JArray)userData.SelectToken("favorites.states");
            if (states != null && states.Count() > 0)
            { 
                foreach (JToken st in states)
                {
                    var stateId = st.SelectToken("id").ToString();
                    var state = allStates.Where(s => s.Id.Equals(stateId,
                        StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                    var locations = (JArray)st.SelectToken("locations");
                    if (locations != null && locations.Count() > 0)
                    {
                        foreach (JValue locationId in locations)
                        {
                            var location = state.Locations.Where(l => l.Id.Equals(locationId.ToString(), 
                                StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                            if (favorites.ContainsKey(state))
                            {
                                favorites[state].Add(location);
                            }
                            else
                            {
                                var locationList = new List<Location2>();
                                locationList.Add(location);

                                favorites.Add(state, locationList);
                            }
                        }
                    }
                }
            }

            return favorites;

            //test loading all schedules, we'd rather load on demand, however, to make everything speedier
            //foreach (KeyValuePair<State2, List<Location2>> kvp in favorites)
            //{
            //    foreach (Location2 location in kvp.Value)
            //    {
            //        var dailySchedule = await LoadDailyScheduleByStateIdAndLocationId(DateTime.Now, kvp.Key.Id, location.Id);
            //        location.DailySchedules.Add(dailySchedule);
            //    }
            //}
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            //StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            //localSettings.Values["userData"] = txtInput.Text;

            LocalSettingsHelper.AddSetting("userData", txtInput.Text);
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            // txtDisplay is a TextBlock defined in XAML.
            txtDisplay.Text = "USER DATA: ";

            //ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            //Object value = localSettings.Values["userData"];

            var value = LocalSettingsHelper.GetSetting("userData");

            txtDisplay.Text += value as string;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            //ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            //localSettings.Values.Remove("userData");

            LocalSettingsHelper.RemoveSetting("userData");
        }
    }
}