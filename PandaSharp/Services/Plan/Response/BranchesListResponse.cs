using System.Collections.Generic;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Plan.Response
{
    public sealed class BranchesListResponse : ListResponseBase<BranchResponse>
    {
        [DeserializeAs(Name = "branch")]
        public override List<BranchResponse> InnerList { get; set; }
    }
}