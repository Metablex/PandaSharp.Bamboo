using System.Collections.Generic;
using Newtonsoft.Json;
using PandaSharp.Framework.Services.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    public sealed class PlanResponse
    {
        [JsonProperty("projectKey")]
        public string ProjectKey { get; set; }

        [JsonProperty("projectName")]
        public string ProjectName { get; set; }

        [JsonProperty("shortName")]
        public string PlanName { get; set; }

        [JsonProperty("shortKey")]
        public string PlanKey { get; set; }

        [JsonProperty("enabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("isFavourite")]
        public bool IsFavourite { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("isBuilding")]
        public bool IsBuilding { get; set; }

        [JsonConverter(typeof(JsonListResponseConverter<ActionResponse>), "action")]
        [JsonProperty("actions")]
        public List<ActionResponse> Actions { get; set; }

        [JsonConverter(typeof(JsonListResponseConverter<StageResponse>), "stage")]
        [JsonProperty("stages")]
        public List<StageResponse> Stages { get; set; }

        [JsonConverter(typeof(JsonListResponseConverter<BranchResponse>), "branch")]
        [JsonProperty("branches")]
        public List<BranchResponse> Branches { get; set; }

        [JsonConverter(typeof(JsonListResponseConverter<VariableResponse>), "variable")]
        [JsonProperty("variableContext")]
        public List<VariableResponse> Variables { get; set; }
    }
}