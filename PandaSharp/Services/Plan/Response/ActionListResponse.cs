using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Plan.Response
{
    public sealed class ActionListResponse : ListResponseBase
    {
        [DeserializeAs(Name = "action")]
        public List<ActionResponse> Contents { get; set; }
    }
}