using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class StagesResponse : ListResponseBase
    {
        [DeserializeAs(Name = "stage")]
        public List<StageResponse> Contents { get; set; }
    }
}