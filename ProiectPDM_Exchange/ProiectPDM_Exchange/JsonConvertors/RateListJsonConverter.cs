using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProiectPDM_Exchange.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectPDM_Exchange.JsonConvertors
{
    public class RateListJsonConverter : JsonConverter
    {
        #region implemented abstract members of JsonConverter

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject settingsObj = JObject.Load(reader);
            var list = new List<Rate>();

            foreach (KeyValuePair<string, JToken> entry in settingsObj)
            {
                var rate = new Rate
                {
                    Name = entry.Key,
                    Value = Convert.ToDouble(entry.Value)
                };
                list.Add(rate);
            }

            return list;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<Rate>);
        }

        #endregion
    }
}
