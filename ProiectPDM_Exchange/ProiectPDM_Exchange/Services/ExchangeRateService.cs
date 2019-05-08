using Newtonsoft.Json;
using ProiectPDM_Exchange.Constants;
using ProiectPDM_Exchange.Entities;
using System;
using System.Net.Http;
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
            var address = ApiStrings.Latest + currencyName;
            var json = await httpClient.GetStringAsync(address);
            var exchangeRate = JsonConvert.DeserializeObject<ExchangeRate>(json);

            return exchangeRate;
        }

        public async Task<ExchangeRate> GetRatesForDate(string currencyName, DateTime dateTime)
        {
            var address = ApiStrings.Base + dateTime.ToString("yyyy-MM-dd") + "?base=" + currencyName;
            var json = await httpClient.GetStringAsync(address);
            var exchangeRate = JsonConvert.DeserializeObject<ExchangeRate>(json);

            return exchangeRate;
        }
    }
}
