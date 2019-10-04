using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class JiraIssueResponse
    {
        [DeserializeAs(Name = "key")]
        public string Name { get; set; }

        [DeserializeAs(Name = "summary")]
        public string Summary { get; set; }

        [DeserializeAs(Name = "issueType")]
        public string IssueType { get; set; }

        [DeserializeAs(Name = "status")]
        public string Status { get; set; }

        [DeserializeAs(Name = "assignee")]
        public string Assignee { get; set; }

        [DeserializeAs(Name = "url")]
        public LinkResponse LinkedIssue { get; set; }
    }
}