using CorePowerYoges.BLL;
using CorePowerYoges.DAL;
using CorePowerYoges.Models;
using CorePowerYoges.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.ConsoleTester
{
    class Program
    {
        private static LocationBL blLocation;
        private static DailyScheduleBL blDailySchedule;

        static void Main(string[] args)
        {
            Init();

            PrintAllStatesWithLocations();

            PrintAllLocationsInState("MN");

            PrintDailyScheduleForLocation(DateTime.Now, "864_3");

            PrintDailyScheduleForLocation(DateTime.Now, "864_3");

            //PrintDailyScheduleForLocation(DateTime.Now.AddDays(1), "864_3");

            Console.ReadLine();
        }

        private static void Init()
        {
            var locationFromDiskLoader = new LocationFromDiskLoader(ConfigurationHelpers.LocationListPath);
            blLocation = new LocationBL(locationFromDiskLoader,
                ConfigurationHelpers.AllLocationCacheDurationInMinutes);

            var websiteScraper = new CorePowerWebsiteScraper(ConfigurationHelpers.WebsiteScraperUrlBaseFormatString,
                ConfigurationHelpers.WebsiteScraperUrlShortDateFormat);            
            blDailySchedule = new DailyScheduleBL(websiteScraper, 
                ConfigurationHelpers.DailyScheduleForLocationCacheDurationInMinutes);
        }

        private static void PrintDailyScheduleForLocation(DateTime dateTime, string locationId)
        {
            var location = blLocation.GetLocationById(locationId);
            var dailySchedule = blDailySchedule.GetDailyScheduleForLocation(dateTime, location);

            Console.WriteLine(string.Format("{0}: ", location.Name));

            foreach (Session session in dailySchedule.Sessions)
            {
                Console.WriteLine(string.Format("{0} ({1})", session.Name, session.Teacher));
            }
        }

        private static void PrintAllLocationsInState(string stateAbbr)
        {
            var locations = blLocation.GetLocationsInState(stateAbbr);

            if (locations.Count() > 0)
            {
                Console.WriteLine(stateAbbr);
            }

            foreach (Location l in locations)
            {
                Console.WriteLine(string.Format("{0}: {1}", l.Id, l.Name));
            }
        }

        private static void PrintAllStatesWithLocations()
        {
            var locations = blLocation.GetAllLocations();
            var states = locations.Select(l => l.State).Distinct();

            foreach (State s in states)
            {
                Console.WriteLine(string.Format("{0} ({1}) - {2}",
                    s.Name,
                    s.Abbreviation,
                    s.Id));
            }
        }
    }
}
