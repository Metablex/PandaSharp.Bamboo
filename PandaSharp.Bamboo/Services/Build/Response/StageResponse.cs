using Newtonsoft.Json;

namespace PandaSharp.Bamboo.Services.Build.Response
{
    public sealed class StageResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("lifeCycleState")]
        public string LifeCycleSate { get; set; }

        [JsonProperty("manual")]
        public bool IsManual { get; set; }

        [JsonProperty("restartable")]
        public bool IsRestartable { get; set; }

        [JsonProperty("runnable")]
        public bool IsRunnable { get; set; }
    }
}