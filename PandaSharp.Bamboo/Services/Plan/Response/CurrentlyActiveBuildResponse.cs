using Newtonsoft.Json;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    public sealed class CurrentlyActiveBuildResponse
    {
        [JsonProperty("lifeCycleState")]
        public string LifeCycleState { get; set; }

        [JsonProperty("number")]
        public int BuildNumber { get; set; }
    }
}