﻿using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CorePowerYoges.DAL
{
    // TODO: replace with DB
    public class StateListDiskLoader : IStateRepository
    {
        private string stateListPath;

        public StateListDiskLoader(string stateListPath)
        {
            this.stateListPath = stateListPath;
        }

        //private IEnumerable<Location> LoadLocationListFromDisk(string filename)
        //{
        //    List<Location> locations = new List<Location>();

        //    if (File.Exists(filename))
        //    {
        //        XDocument locationList = XDocument.Load(filename);
        //        foreach (XElement stateElem in locationList.Descendants("State"))
        //        {
        //            var stateId = stateElem.Attribute("id").Value;

        //            foreach (XElement locationElem in stateElem.Descendants("Location"))
        //            {
        //                var name = locationElem.Attribute("name").Value;
        //                var id = locationElem.Attribute("id").Value;
        //                var location = new Location(name, id, stateId);

        //                locations.Add(location);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        throw new FileNotFoundException("LocationList File Not Found", filename);
        //    }

        //    return locations;
        //}

        private IEnumerable<State> LoadStateListFromDisk(string filename)
        {
            List<State> states = new List<State>();

            if (File.Exists(filename))
            {
                XDocument locationList = XDocument.Load(filename);
                foreach (XElement stateElem in locationList.Descendants("State"))
                {
                    var abbreviation = stateElem.Attribute("abbr").Value;
                    var name = stateElem.Attribute("name").Value;
                    var id = stateElem.Attribute("id").Value;
                    var state = new State(abbreviation, name, id);

                    foreach (XElement locationElem in stateElem.Descendants("Location"))
                    {
                        name = locationElem.Attribute("name").Value;
                        id = locationElem.Attribute("id").Value;
                        var location = new Location(name, id, state.Id);

                        state.Locations.Add(location);
                    }

                    states.Add(state);
                }
            }
            else
            {
                throw new FileNotFoundException("LocationList File Not Found", filename);
            }

            return states;
        }

        public IEnumerable<State> GetAllStates()
        {
            return LoadStateListFromDisk(stateListPath).OrderBy(l => l.Name);
        }
    }
}