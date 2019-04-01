using Newtonsoft.Json;
using ProiectPDM_Exchange.Constants;
using ProiectPDM_Exchange.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPDM_Exchange.Services
{
    public class ExchangeRateService
    {
        private readonly HttpClient httpClient;

        public ExchangeRateService()
        {
            httpClient = new HttpClient();
        }

        public async Task<ExchangeRate> GetTodayRates(string currencyName)
        {
            var json = await httpClient.GetStringAsync(ApiStrings.Latest + currencyName);
            var exchangeRate = JsonConvert.DeserializeObject<ExchangeRate>(json);

            return exchangeRate;
        }
    }
}
