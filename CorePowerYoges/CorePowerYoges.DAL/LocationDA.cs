using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CorePowerYoges.DAL
{
    public class LocationDA : ILocationDA
    {
        public LocationDA()
        {
        }

        public List<Location> GetAllLocations()
        {
            // TODO replace with external value
            string locationListPath = @"C:\Users\Matthew\GitProjects\CorePowerYoges\CorePowerYoges\CorePowerYoges.DAL\Data\LocationList.xml";

            return LoadLocationsFromDisk(locationListPath); 
        }

        private List<Location> LoadLocationsFromDisk(string filename)
        {
            List<Location> locations = new List<Location>();
            if (File.Exists(filename))
            {
                XDocument locationList = XDocument.Load(filename);
                foreach (XElement stateElem in locationList.Descendants("State"))
                {
                    var state = new State()
                    {
                        Abbreviation = stateElem.Attribute("abbr").Value,
                        Name = stateElem.Attribute("name").Value,
                        Id = stateElem.Attribute("id").Value
                    };

                    foreach (XElement locationElem in stateElem.Descendants("Location"))
                    {
                        var location = new Location()
                        {
                            Id = locationElem.Attribute("id").Value,
                            Name = locationElem.Attribute("name").Value,
                            State = state
                        };

                        locations.Add(location);
                    }                    
                }
            }
            else
            {
                throw new FileNotFoundException();
            }

            return locations;
        }
    }
}
