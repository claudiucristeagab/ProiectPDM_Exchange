using Newtonsoft.Json;
using ProiectPDM_Exchange.JsonConvertors;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectPDM_Exchange.Entities
{
    
    public class ExchangeRate
    {
        [JsonProperty("rates")]
        [JsonConverter(typeof(RateListJsonConverter))]
        public List<Rate> Rates { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        public ExchangeRate()
        {
            Rates = new List<Rate>();
        }
    }

}
