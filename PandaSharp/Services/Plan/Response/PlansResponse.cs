using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Plan.Response
{
    public sealed class PlansResponse : ListResponseBase
    {
        [DeserializeAs(Name = "plan")]
        public List<PlanResponse> Contents { get; set; }
    }
}
