using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class ArtifactsResponse : ListResponseBase<ArtifactResponse>
    {
        [DeserializeAs(Name = "artifact")]
        public override List<ArtifactResponse> InnerList { get; set; }
    }
}