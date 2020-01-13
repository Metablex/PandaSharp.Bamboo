using System.Collections.Generic;
using Newtonsoft.Json;
using PandaSharp.Bamboo.Services.Plan.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    public sealed class PlanResponse
    {
        [JsonProperty("projectKey")]
        public string ProjectKey { get; set; }

        [JsonProperty("projectName")]
        public string ProjectName { get; set; }

        [JsonProperty("name")]
        public string LongPlanName { get; set; }

        [JsonProperty("shortName")]
        public string ShortPlanName { get; set; }

        [JsonProperty("key")]
        public string LongPlanKey { get; set; }

        [JsonProperty("shortKey")]
        public string ShortPlanKey { get; set; }

        [JsonProperty("enabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("isFavourite")]
        public bool? IsFavourite { get; set; }

        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

        [JsonProperty("isBuilding")]
        public bool? IsBuilding { get; set; }

        [JsonProperty("actions")]
        [JsonConverter(typeof(ActionListResponseConverter))]
        public List<ActionResponse> Actions { get; set; }

        [JsonProperty("stages")]
        [JsonConverter(typeof(StageListResponseConverter))]
        public List<StageResponse> Stages { get; set; }

        [JsonProperty("branches")]
        [JsonConverter(typeof(BranchListResponseConverter))]
        public List<BranchResponse> Branches { get; set; }

        [JsonProperty("variableContext")]
        [JsonConverter(typeof(VariableContextListResponseConverter))]
        public List<VariableResponse> Variables { get; set; }
    }
}