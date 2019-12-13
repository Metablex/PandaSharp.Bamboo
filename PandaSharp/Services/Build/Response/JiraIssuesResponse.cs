using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class JiraIssuesResponse : ListResponseBase
    {
        [DeserializeAs(Name = "issue")]
        public List<JiraIssueResponse> Contents { get; set; }
    }
}