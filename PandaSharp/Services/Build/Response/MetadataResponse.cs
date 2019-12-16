using Newtonsoft.Json;

namespace PandaSharp.Services.Build.Response
{
    public sealed class MetadataResponse
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}