using Newtonsoft.Json;
using ProiectPDM_Exchange.JsonConvertors;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectPDM_Exchange.Entities
{    
    public class Rate
    {
        [JsonProperty("key")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public double Value { get; set; }
    }
}
