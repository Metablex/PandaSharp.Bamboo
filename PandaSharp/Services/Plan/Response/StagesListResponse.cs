using System.Collections.Generic;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Plan.Response
{
    public sealed class StagesListResponse : ListResponseBase<StageResponse>
    {
        [DeserializeAs(Name = "stage")]
        public override List<StageResponse> InnerList { get; set; }
    }
}