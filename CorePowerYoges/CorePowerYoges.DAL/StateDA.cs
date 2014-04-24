using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorePowerYoges.Models;
using System.Web;
using System.Web.Caching;
using System.Xml.Linq;
using System.IO;

namespace CorePowerYoges.DAL
{
    public class StateDA : IStateDA
    {
        protected Cache cache = HttpRuntime.Cache;

        protected List<State> AllStatesAndLocations
        {
            get
            {
                string allStatesAndLocationsCacheKey = "StateDA.AllStatesAndLocations";
                string locationListPath = @"C:\Users\Matthew\SkyDrive\Project Assets\CorePowerYoges\Source\CorePowerYoges\CorePowerYoges\CorePowerYoges.DAL\Data\LocationList.xml";

                List<State> allStatesFromCache = (List<State>)cache.Get(allStatesAndLocationsCacheKey);
                if (allStatesFromCache == null)
                {
                    allStatesFromCache = LoadLocationListFromDisk(locationListPath);
                    cache.Insert(allStatesAndLocationsCacheKey, allStatesFromCache, new CacheDependency(locationListPath));
                }
                return allStatesFromCache;
            }
        }
        
        public StateDA()
        {
        }

        public List<State> GetAllStatesAndLocations()
        {
            return AllStatesAndLocations;
        }

        private List<State> LoadLocationListFromDisk(string filename)
        {
            List<State> states = new List<State>();
            if (File.Exists(filename))
            {
                XDocument locationList = XDocument.Load(filename);                
                foreach (XElement stateElem in locationList.Descendants("State"))
                {
                    var state = new State()
                    {
                        Abbreviation = stateElem.Attribute("id").Value,
                        Name = stateElem.Attribute("name").Value
                    };                       

                    foreach(XElement locationElem in stateElem.Descendants("Location"))
                    {
                        var location = new Location()
                        {
                            Id = locationElem.Attribute("id").Value,
                            Name = locationElem.Attribute("name").Value
                        };
                        state.Locations.Add(location);
                    }
                    states.Add(state);
                }
            }
            else
            {
                throw new FileNotFoundException();
            }

            return states;
        }
    }
}
