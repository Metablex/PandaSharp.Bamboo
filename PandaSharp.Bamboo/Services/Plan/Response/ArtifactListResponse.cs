using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<ArtifactListResponse, ArtifactResponse>))]
    [JsonRootElementPath("artifacts")]
    [JsonListContentPath("artifacts.artifact.[*]")]
    public sealed class ArtifactListResponse : ListResponseBase<ArtifactResponse>
    {
    }
}