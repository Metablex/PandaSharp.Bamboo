using Newtonsoft.Json;

namespace PandaSharp.Services.Build.Response
{
    public sealed class VariableResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}