using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Collections.ObjectModel;
using CorePowerYoges.WinPhone.Repository;

namespace CorePowerYoges.Models
{
    public class UserData
    {
        public Dictionary<State, List<Location>> Favorites { get; set; }

        public UserData(string userData)
        {
            
        }

        private void LoadFavorites(string userData)
        {

        }

        public void AddFavorite(string locationId)
        {
            throw new NotImplementedException();
        }

        public void AddFavorite(Location location)
        {
            throw new NotImplementedException();
        }        

        private async Task<Dictionary<State, List<Location>>> LoadFavoritesAsync(JObject userData)
        {
            var favorites = new Dictionary<State, List<Location>>();
            var allStates = await LoadAllStatesAsync();

            var states = (JArray)userData.SelectToken("favorites.states");
            if (states != null && states.Count > 0)
            {
                foreach (JToken st in states)
                {
                    var stateId = st.SelectToken("id").ToString();
                    var state = allStates.Where(s => s.Id.Equals(stateId,
                        StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                    var locations = (JArray)st.SelectToken("locations");
                    if (locations != null && locations.Count > 0)
                    {
                        foreach (JValue locationId in locations)
                        {
                            var location = state.Locations.Where(l => l.CorePowerYogaLocationId.Equals(locationId.ToString(),
                                StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                            if (favorites.ContainsKey(state))
                            {
                                favorites[state].Add(location);
                            }
                            else
                            {
                                var locationList = new List<Location>();
                                locationList.Add(location);

                                favorites.Add(state, locationList);
                            }
                        }
                    }
                }
            }

            return favorites;
        }

        public async Task<ObservableCollection<State>> LoadAllStatesAsync()
        {
            IStateRepository repository = new StateRepository();
            return await repository.GetAllStatesAsync();
        }
    }
}
