using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Plan.Response
{
    public sealed class ActionListResponse : ListResponseBase<ActionResponse>
    {
        [DeserializeAs(Name = "action")]
        public override List<ActionResponse> InnerList { get; set; }
    }
}