using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Plan.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    [JsonConverter(typeof(ArtifactListRootElementResponseConverter))]
    [JsonItems("artifact")]
    public sealed class ArtifactListResponse : ListResponseBase<ArtifactResponse>
    {
    }
}