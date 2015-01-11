using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CorePowerYoges.WinPhone.Repository
{
    public class DailyScheduleRepository : IDailyScheduleRepository
    {
        public async Task<DailySchedule> GetDailyScheduleByStateIdAndLocationIdAsync(DateTime date, string stateId, string locationId)
        {
            string baseUrl = "http://nagas.azurewebsites.net/";
            string requestUriFormat = "api/dailyschedule?date={0}&stateId={1}&locationId={2}";

            DailySchedule dailySchedule = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(string.Format(requestUriFormat, date.ToString("yyyy-MM-dd"), stateId, locationId));
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    dailySchedule = await response.Content.ReadAsAsync<DailySchedule>();
                }
            }

            return dailySchedule;
        }
    }
}
