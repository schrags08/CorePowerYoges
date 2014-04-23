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
        public StateDA()
        {
            var cache = HttpRuntime.Cache;

            List<State> states = (List<State>)cache.Get("states");
            if (states == null)
            {
                string path = @"C:\Users\Matthew\SkyDrive\Project Assets\CorePowerYoges\Source\CorePowerYoges\CorePowerYoges\CorePowerYoges.DAL\Data\LocationList.xml";
                states = LoadLocationListFromDisk(path);
            }
        }

        private List<State> LoadLocationListFromDisk(string filename)
        {
            List<State> states = new List<State>();

            if (File.Exists(filename))
            {
                XDocument locationList = XDocument.Load(filename);
                if (locationList != null)
                {
                    foreach (XElement state in locationList.Descendants("State"))
                    {
                        var tmpState = new State()
                        {
                            Name = state.Attribute("name").Value,
                            Abbreviation = state.Attribute("id").Value
                        };                       

                        foreach(XElement location in state.Descendants("Location"))
                        {
                            var tmpLocation = new Location();
                            tmpLocation.Id = location.Attribute("id").Value;
                            tmpLocation.Name = location.Attribute("name").Value;
                            tmpState.Locations.Add(tmpLocation);
                        }

                        states.Add(tmpState);
                    }
                }
            }
            else
            {
                throw new FileNotFoundException();
            }

            return states;
        }

        public List<State> GetAllStates()
        {
            throw new NotImplementedException();
        }
    }
}
