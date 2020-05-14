using Newtonsoft.Json;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    public sealed class BranchResponse
    {
        [JsonProperty("shortName")]
        public string BranchName { get; set; }

        [JsonProperty("shortKey")]
        public string BranchKey { get; set; }

        [JsonProperty("enabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}