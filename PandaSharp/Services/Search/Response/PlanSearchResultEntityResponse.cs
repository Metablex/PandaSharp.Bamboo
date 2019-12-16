using Newtonsoft.Json;

namespace PandaSharp.Services.Search.Response
{
    public sealed class PlanSearchResultEntityResponse
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