using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class JiraIssuesResponse : ListResponseBase<JiraIssueResponse>
    {
        [DeserializeAs(Name = "issue")]
        public override List<JiraIssueResponse> InnerList { get; set; }
    }
}