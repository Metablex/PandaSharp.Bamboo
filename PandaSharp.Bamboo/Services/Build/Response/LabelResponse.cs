using Newtonsoft.Json;

namespace PandaSharp.Bamboo.Services.Build.Response
{
    public sealed class LabelResponse
    {
        [JsonProperty("name")]
        public string Label { get; set; }
    }
}