using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class BuildsResponse : ListResponseBase
    {
        [DeserializeAs(Name = "result")]
        public List<BuildResponse> Contents { get; set; }
    }
}