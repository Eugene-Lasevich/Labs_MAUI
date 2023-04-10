using MauiApp1.Lab4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1.Lab4.Services
{
    class RateService : IRateService
    {
        static HttpClient httpClient = new HttpClient();

        public async Task<IEnumerable<Rate>>GetRates(DateTime date)
        {
            List<int> _ArrayOfCurrenciesId = new List<int>() { 456, 451, 431, 426, 462, 429, 452, 298 };
            var response = await httpClient.GetAsync($"https://www.nbrb.by/api/exrates/rates?ondate={date:yyyy-M-d}&periodicity=0");
            var tmp = await response.Content.ReadAsStringAsync();
            var RateItems = new List<Rate>();
            RateItems = JsonSerializer.Deserialize<List<Rate>>(tmp);
           

            var tmp1 = RateItems.Where(x => _ArrayOfCurrenciesId.Contains(x.Cur_ID));
            return tmp1;

        }
    }
}
