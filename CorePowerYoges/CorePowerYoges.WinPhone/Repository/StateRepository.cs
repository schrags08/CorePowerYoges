using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace CorePowerYoges.WinPhone.Repository
{
    public class StateRepository : IStateRepository
    {
        const string baseUrl = "http://api.nagas.co/";
        const string requestUriFormat = "api/dailyschedules/{0}";

        public async Task<ObservableCollection<State>> GetAllStatesAsync()
        {
            //string baseUrl = "http://localhost/CorePowerYoges.WebAPI/";
            string baseUrl = "http://nagas.azurewebsites.net/";
            string requestUri = "api/state";

            ObservableCollection<State> allStates = new ObservableCollection<State>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    allStates = await response.Content.ReadAsAsync<ObservableCollection<State>>();
                }
            }

            return allStates;
        }
    }
}
