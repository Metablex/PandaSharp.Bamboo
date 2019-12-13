using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class ArtifactsResponse : ListResponseBase
    {
        [DeserializeAs(Name = "artifact")]
        public List<ArtifactResponse> Contents { get; set; }
    }
}