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
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            this.txtInput.Text = "{ 'settings': { 'favoriteLocations': [ '864_16', '864_15', '864_17', '864_7', '110_6', '110_5'] } }";
            LocalSettingsHelper.AddSetting("userData", txtInput.Text);

            LoadFavorites();
        }

        private ObservableCollection<State> _allStates;
        public async Task LoadAllStates()
        {
            IStateRepository repository = new StateRepository();
            _allStates = await repository.GetAllStatesAsync();
        }

        private DailySchedule _dailySchedule;
        public async Task LoadDailyScheduleByStateIdAndLocationId(DateTime date, string stateId, string locationId)
        {
            IDailyScheduleRepository repository = new DailyScheduleRepository();
            _dailySchedule = await repository.GetDailyScheduleByStateIdAndLocationIdAsync(date, stateId, locationId);
        }

        private Location _location;
        public async Task LoadLocationById(string locationId)
        {
            ILocationRepository repository = new LocationRepository();
            _location = await repository.GetLocationByIdAsync(locationId);
        }

        private async Task LoadFavorites()
        {
            var jim = JObject.Parse(LocalSettingsHelper.GetSetting("userData"));
            var favoriteLocations = (JArray)jim.SelectToken("settings.favoriteLocations");
            var currentFavorites = new List<string>();

            if (favoriteLocations != null && favoriteLocations.Count() > 0)
            {
                foreach (JValue location in favoriteLocations)
                {
                    var name = location.Value as string;
                    currentFavorites.Add(name);
                }
            }

            //await LoadAllStates();
            //await LoadDailyScheduleByStateIdAndLocationId(DateTime.Now, "ec4baf3", "110_6");
            await LoadLocationById("110_6");
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