using Newtonsoft.Json;

namespace PandaSharp.Services.Plan.Response
{
    public sealed class StageResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("manual")]
        public bool IsManual { get; set; }
    }
}