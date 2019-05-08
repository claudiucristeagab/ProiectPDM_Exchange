using Newtonsoft.Json;

namespace ProiectPDM_Exchange.Entities
{
    public class Rate
    {
        [JsonProperty("key")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public double Value { get; set; }
        public string ImageUri { get; set; }
    }
}
