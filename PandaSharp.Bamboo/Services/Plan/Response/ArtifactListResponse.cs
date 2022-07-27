using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;
using PandaSharp.Framework.Services.Response;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<ArtifactListResponse, ArtifactResponse>))]
    [JsonRootElementPath("artifacts")]
    [JsonListContentPath("artifacts.artifact.[*]")]
    public sealed class ArtifactListResponse : ListResponseBase<ArtifactResponse>
    {
    }
}