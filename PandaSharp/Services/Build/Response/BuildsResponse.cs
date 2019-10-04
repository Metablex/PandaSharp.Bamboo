using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class BuildsResponse : ListResponseBase<BuildResponse>
    {
        [DeserializeAs(Name = "result")]
        public override List<BuildResponse> InnerList { get; set; }
    }
}