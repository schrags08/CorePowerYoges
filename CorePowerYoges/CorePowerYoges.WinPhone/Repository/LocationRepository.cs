using CorePowerYoges.Models;
using CorePowerYoges.WinPhone.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CorePowerYoges.WinPhone.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly string baseUrl = AppResourcesHelper.GetValue("ApiBaseUrl");

        public async Task<Location> GetLocationByIdAsync(string locationId)
        {
            string requestUri = AppResourcesHelper.GetValue("LocationRequestUri");

            Location location = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(string.Format(requestUri, locationId));
                if (response.IsSuccessStatusCode)
                {
                    location = await response.Content.ReadAsAsync<Location>();
                }
            }

            return location;
        }
    }
}
