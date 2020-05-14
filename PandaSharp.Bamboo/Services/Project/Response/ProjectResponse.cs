using System.Collections.Generic;
using Newtonsoft.Json;
using PandaSharp.Bamboo.Services.Common.Response.Converter;
using PandaSharp.Bamboo.Services.Plan.Response;

namespace PandaSharp.Bamboo.Services.Project.Response
{
    public class ProjectResponse
    {
        [JsonProperty("key")]
        public string ProjectKey { get; set; }

        [JsonProperty("name")]
        public string ProjectName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonConverter(typeof(JsonListResponseConverter<PlanResponse>), "plan")]
        [JsonProperty("plans")]
        public List<PlanResponse> Plans { get; set; }
    }
}