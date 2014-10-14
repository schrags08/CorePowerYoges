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
    public class StateBL
    {
        private Cache cache = HttpRuntime.Cache;
        private ILocationDA locationDA;
        private int allStateCacheDurationInMinutes;

        public StateBL(ILocationDA locationDA, int allStateCacheDurationInMinutes = 1440)
        {
            this.locationDA = locationDA;
            this.allStateCacheDurationInMinutes = allStateCacheDurationInMinutes;
        }

        public IEnumerable<State> GetAllStates()
        {
            string cacheKey = "StateBL-AllStates";
            IEnumerable<State> dataFromCache = (IEnumerable<State>)cache.Get(cacheKey);

            if (dataFromCache == null)
            {
                // no data in cache, reload from Data Access Layer
                dataFromCache = locationDA.GetAllStates();

                // insert item into cache
                cache.Insert(cacheKey, 
                    dataFromCache, 
                    null, 
                    DateTime.Now.AddMinutes(allStateCacheDurationInMinutes), 
                    Cache.NoSlidingExpiration);
            }

            return dataFromCache;
        }

        public State GetStateById(string id)
        {
            return GetAllStates()
                .Where(s => s.Id == id).FirstOrDefault();
        }

        public State GetStateByAbbreviation(string stateAbbr)
        {
            return GetAllStates()
                .Where(s => s.Abbreviation == stateAbbr.ToUpper()).FirstOrDefault();
        }    
    }
}
