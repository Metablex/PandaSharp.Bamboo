using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class StagesResponse : ListResponseBase<StageResponse>
    {
        [DeserializeAs(Name = "stage")]
        public override List<StageResponse> InnerList { get; set; }
    }
}