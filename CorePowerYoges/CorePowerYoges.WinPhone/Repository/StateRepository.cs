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
using CorePowerYoges.WinPhone.Utils;

namespace CorePowerYoges.WinPhone.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly string baseUrl = AppResourcesHelper.GetValue("ApiBaseUrl");

        public async Task<ObservableCollection<State>> GetAllStatesAsync()
        {
            string requestUri = AppResourcesHelper.GetValue("StateRequestUri"); ;

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
