using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PandaSharp.Services.Common.Response.Converter
{
    internal abstract class JsonListResponseConverterBase<T> : JsonConverter<List<T>>
    {
        protected abstract string ItemsPath { get; }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, List<T> value, JsonSerializer serializer)
        {
        }

        public override List<T> ReadJson(JsonReader reader, Type objectType, List<T> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var json = JObject.Load(reader);
            var items = json.SelectToken(ItemsPath);

            if (items != null && items.HasValues)
            {
                return items.ToObject<List<T>>();
            }

            return new List<T>();
        }
    }
}