using CorePowerYoges.BLL;
using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            LocationBL blLocation = new LocationBL();
            var locations = blLocation.GetAllLocations();

            var states = locations.Select(l => l.State).Distinct();

            foreach (State s in locations.Select(l => l.State).Distinct())
            {
                Console.WriteLine(string.Format("{0} ({1})", s.Name, s.Abbreviation));

                foreach (Location l in blLocation.GetLocationsInState(s).OrderBy(l => l.Name))
                {
                    Console.WriteLine(string.Format("\t{0}: {1}", l.Id, l.Name));
                }
            }

            string laJolla = blLocation.GetLocationNameById("1419_6");
            Console.WriteLine(string.Format("==={0}", laJolla));

            Console.ReadLine();
        }
    }
}
