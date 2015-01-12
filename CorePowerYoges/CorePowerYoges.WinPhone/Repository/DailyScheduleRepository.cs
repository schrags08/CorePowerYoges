using CorePowerYoges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using CorePowerYoges.WinPhone.Utils;

namespace CorePowerYoges.WinPhone.Repository
{
    public class DailyScheduleRepository : IDailyScheduleRepository
    {
        private readonly string baseUrl = AppResourcesHelper.GetValue("ApiBaseUrl");

        public async Task<DailySchedule> GetDailyScheduleByStateIdAndLocationIdAsync(DateTime date, string stateId, string locationId)
        {
            string requestUriFormat = AppResourcesHelper.GetValue("DailyScheduleRequestUriFormat");

            DailySchedule dailySchedule = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(string.Format(requestUriFormat, date.ToString("yyyy-MM-dd"), stateId, locationId));
                if (response.IsSuccessStatusCode)
                {
                    dailySchedule = await response.Content.ReadAsAsync<DailySchedule>();
                }
            }

            return dailySchedule;
        }
    }
}
