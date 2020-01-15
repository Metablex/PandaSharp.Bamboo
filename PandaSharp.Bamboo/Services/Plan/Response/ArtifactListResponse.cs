using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<ArtifactListResponse, ArtifactResponse>))]
    [JsonItems("artifact")]
    [JsonRootElement("artifacts")]
    public sealed class ArtifactListResponse : ListResponseBase<ArtifactResponse>
    {
    }
}