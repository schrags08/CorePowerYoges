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
    public class LocationListDiskLoader : ILocationDA
    {
        private string locationListPath;

        public LocationListDiskLoader(string locationListPath)
        {
            this.locationListPath = locationListPath;
        }

        private IEnumerable<Location> LoadLocationsFromDisk(string filename)
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

        public IEnumerable<Location> GetAllLocations()
        {
            return LoadLocationsFromDisk(locationListPath).OrderBy(l => l.Name);
        }
    }
}
