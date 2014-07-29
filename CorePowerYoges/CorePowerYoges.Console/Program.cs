using CorePowerYoges.BLL;
using CorePowerYoges.Models;
using CorePowerYoges.Scraper;
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

            PrintAllLocationsInState("IL");

            PrintDailyScheduleForLocation(DateTime.Now, "864_3");

            PrintDailyScheduleForLocation(DateTime.Now, "864_3");

            Console.ReadLine();
        }

        private static void Init()
        {
            blLocation = new LocationBL();            
            blDailySchedule = new DailyScheduleBL();
        }

        private static void PrintDailyScheduleForLocation(DateTime dateTime, string locationId)
        {
            var location = blLocation.GetLocationById(locationId);
            var dailySchedule = blDailySchedule.GetDailyScheduleForLocation(dateTime, location);

            //throw new NotImplementedException();
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

            foreach (State s in locations.Select(l => l.State).Distinct())
            {
                Console.WriteLine(string.Format("{0} ({1}) - {2}",
                    s.Name,
                    s.Abbreviation,
                    s.Id));
            }
        }
    }
}
