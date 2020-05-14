using Newtonsoft.Json;

namespace PandaSharp.Bamboo.Services.Common.Response
{
    public sealed class LabelResponse
    {
        [JsonProperty("name")]
        public string Label { get; set; }
    }
}