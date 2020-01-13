using Newtonsoft.Json;
using PandaSharp.Bamboo.Services.Common.Response;

namespace PandaSharp.Bamboo.Services.Build.Response
{
    public sealed class JiraIssueResponse
    {
        [JsonProperty("key")]
        public string Name { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("issueType")]
        public string IssueType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("assignee")]
        public string Assignee { get; set; }

        [JsonProperty("url")]
        public LinkResponse LinkedIssue { get; set; }
    }
}