using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;
using PandaSharp.Framework.Services.Response;

namespace PandaSharp.Bamboo.Services.Build.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<BuildListResponse, BuildResponse>))]
    [JsonRootElementPath("results")]
    [JsonListContentPath("results.result.[*]")]
    public sealed class BuildListResponse : ListResponseBase<BuildResponse>
    {
    }
}