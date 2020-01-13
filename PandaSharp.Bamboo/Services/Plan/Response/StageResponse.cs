using Newtonsoft.Json;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    public sealed class StageResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("manual")]
        public bool IsManual { get; set; }
    }
}