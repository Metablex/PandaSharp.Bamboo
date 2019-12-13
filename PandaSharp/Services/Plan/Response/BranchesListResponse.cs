using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Plan.Response
{
    public sealed class BranchesListResponse : ListResponseBase
    {
        [DeserializeAs(Name = "branch")]
        public List<BranchResponse> Contents { get; set; }
    }
}