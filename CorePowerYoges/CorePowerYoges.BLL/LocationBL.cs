using CorePowerYoges.DAL;
using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace CorePowerYoges.BLL
{
    public class LocationBL
    {
        protected Cache cache = HttpRuntime.Cache;

        protected List<Location> AllLocations
        {
            get
            {
                string locationsCacheKey = "LocationBL.AllLocations";
                List<Location> allLocationsFromCache = (List<Location>)cache.Get(locationsCacheKey);
                if (allLocationsFromCache == null)
                {
                    // no data in cache, reload from Data Access Layer
                    ILocationDA locationDA = new LocationDA();
                    allLocationsFromCache = locationDA.GetAllLocations();

                    // insert item into cache for 1 day
                    // TODO externalize cache time
                    cache.Insert(locationsCacheKey, allLocationsFromCache, null, DateTime.Now.AddMinutes(1440), Cache.NoSlidingExpiration);
                }
                return allLocationsFromCache;
            }
        }

        public List<Location> GetAllLocations()
        {
            return AllLocations;
        }

        public List<Location> GetLocationsInState(State state)
        {
            return AllLocations.Where(l => l.State == state).ToList();
        }
    }
}
