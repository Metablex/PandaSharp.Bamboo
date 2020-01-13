using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace PandaSharp.Bamboo.Rest.Common
{
    public sealed class RestResponseDeserializer : IDeserializer
    {
        public T Deserialize<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}