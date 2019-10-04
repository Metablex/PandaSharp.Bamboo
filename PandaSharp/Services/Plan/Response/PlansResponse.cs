using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Plan.Response
{
    public sealed class PlansResponse : ListResponseBase<PlanResponse>
    {
        [DeserializeAs(Name = "plan")]
        public override List<PlanResponse> InnerList { get; set; }
    }
}
