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
    public class State2Service : IState2Service
    {
        private Cache cache = HttpRuntime.Cache;
        private IState2Repository _stateRepository;
        private int allStateCacheDurationInMinutes;

        public State2Service(IState2Repository stateRepository,
            int allStateCacheDurationInMinutes = 1440)
        {
            this._stateRepository = stateRepository;
            this.allStateCacheDurationInMinutes = allStateCacheDurationInMinutes;
        }

        public IEnumerable<State2> GetAllStates()
        {
            string cacheKey = "StateService2-AllStates";
            IEnumerable<State2> dataFromCache = (IEnumerable<State2>)cache.Get(cacheKey);

            if (dataFromCache == null)
            {
                // no data in cache, reload from Data Access Layer
                dataFromCache = _stateRepository.GetAllStates();

                // insert item into cache
                cache.Insert(cacheKey, 
                    dataFromCache, 
                    null, 
                    DateTime.Now.AddMinutes(allStateCacheDurationInMinutes), 
                    Cache.NoSlidingExpiration);
            }

            return dataFromCache;
        }

        public State2 GetStateById(string id)
        {
            return GetAllStates()
                .Where(s => s.Id == id).FirstOrDefault();
        }

        public State2 GetStateByAbbreviation(string stateAbbr)
        {
            return GetAllStates()
                .Where(s => s.Abbreviation == stateAbbr.ToUpper()).FirstOrDefault();
        }

        public Location2 GetLocationById(string id)
        {
            return GetAllStates().SelectMany(s => s.Locations).FirstOrDefault(l => l.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase));
        }

        public IEnumerable<Location2> GetLocationsByIds(string[] ids)
        {
            var locations = new List<Location2>();

            foreach (string id in ids)
            {
                locations.Add(GetLocationById(id));
            }

            return locations;
        }
    }
}
