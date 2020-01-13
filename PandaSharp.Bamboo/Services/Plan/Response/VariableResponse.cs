using Newtonsoft.Json;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    public sealed class VariableResponse
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("variableType")]
        public string VariableType { get; set; }

        [JsonProperty("isPassword")]
        public bool IsPassword { get; set; }
    }
}