using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PandaSharp.Bamboo.Attributes;

namespace PandaSharp.Bamboo.Services.Common.Response.Converter
{
    internal abstract class RootElementResponseConverterBase<T, TItem> : JsonConverter<T>
        where T : ListResponseBase<TItem>, new()
    {
        protected virtual string RootElement { get; } = null;

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
        }

        public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var result = new T();
            var json = JObject.Load(reader);
            foreach (var property in typeof(T).GetProperties())
            {
                var attribute = property.GetCustomAttribute<JsonPropertyAttribute>();
                if (attribute != null)
                {
                    var propertyValue = json.SelectToken(GetElementPath(attribute.PropertyName));
                    if (propertyValue != null)
                    {
                        property.SetValue(result, propertyValue.ToObject(property.PropertyType));
                    }
                }
            }

            var jsonItemsAttribute = typeof(T).GetCustomAttribute<JsonItems>();
            if (jsonItemsAttribute != null)
            {
                var propertyValue = json.SelectToken(GetElementPath(jsonItemsAttribute.ItemsPath));
                if (propertyValue != null && propertyValue.HasValues)
                {
                    result.AddRange(propertyValue.ToObject<List<TItem>>());
                }
            }

            return result;
        }

        private string GetElementPath(string element)
        {
            return string.IsNullOrEmpty(RootElement)
                ? element
                : $"{RootElement}.{element}";
        }
    }
}