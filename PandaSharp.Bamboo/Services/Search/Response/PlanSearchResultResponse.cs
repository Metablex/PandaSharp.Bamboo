using Newtonsoft.Json;

namespace PandaSharp.Bamboo.Services.Search.Response
{
    public sealed class PlanSearchResultResponse
    {
        [JsonProperty("key")]
        public string FullPlanKey { get; set; }

        [JsonProperty("projectName")]
        public string ProjectName { get; set; }

        [JsonProperty("planName")]
        public string PlanName { get; set; }

        [JsonProperty("branchName")]
        public string BranchName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}