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

            PrintSeparator();

            PrintAllStatesWithLocations();

            PrintSeparator();

            PrintAllLocationsInState("IL");

            PrintSeparator();

            PrintDailyScheduleForLocation(DateTime.Now, "864_23");

            PrintSeparator();

            //PrintDailyScheduleForLocation(DateTime.Now, "864_3");

            //PrintDailyScheduleForLocation(DateTime.Now.AddDays(1), "864_3");

            Console.ReadLine();
        }

        private static void Init()
        {
            var locationListFromDiskLoader = new LocationListFromDiskLoader(ConfigurationHelpers.LocationListPath);
            blLocation = new LocationBL(locationListFromDiskLoader,
                ConfigurationHelpers.AllLocationCacheDurationInMinutes);

            var websiteScraper = new CorePowerWebsiteScraper(ConfigurationHelpers.WebsiteScraperUrlBaseFormatString,
                ConfigurationHelpers.WebsiteScraperUrlShortDateFormat);            
            blDailySchedule = new DailyScheduleBL(websiteScraper, 
                ConfigurationHelpers.DailyScheduleForLocationCacheDurationInMinutes);
        }

        private static void PrintSeparator()
        {
            Console.WriteLine("==============================");
        }

        private static void PrintAllStatesWithLocations()
        {
            var states = blLocation.GetAllStatesContainingLocations();

            if (states.Count() > 0)
            {
                Console.WriteLine("All States With Locations:\n");

                foreach (State state in states)
                {
                    Console.WriteLine(string.Format("{0} ({1}) - {2}",
                        state.Name,
                        state.Abbreviation,
                        state.Id));
                }
            }
        }

        private static void PrintAllLocationsInState(string stateAbbr)
        {
            var locations = blLocation.GetAllLocationsInStateByStateAbbreviation(stateAbbr);

            if (locations.Count() > 0)
            {
                Console.WriteLine(string.Format("All Locations in {0}:\n", stateAbbr));

                foreach (Location location in locations)
                {
                    Console.WriteLine(string.Format("{0} - {1}", location.Name, location.Id));
                }
            }
        }

        private static void PrintDailyScheduleForLocation(DateTime date, string locationId)
        {
            var location = blLocation.GetLocationById(locationId);
            var dailySchedule = blDailySchedule.GetDailyScheduleByLocation(date, location);

            if (dailySchedule.Sessions.Count() > 0)
            {
                Console.WriteLine(string.Format("Daily Schedule for {0} ({1}):\n", 
                    location.Name, 
                    date.ToShortDateString()));

                foreach (Session session in dailySchedule.Sessions)
                {
                    Console.WriteLine(string.Format("{0} ({1})", session.Name, session.Teacher));
                }
            }            
        }
    }
}
