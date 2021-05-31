using Newtonsoft.Json;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;
using PandaSharp.Framework.Attributes;

namespace PandaSharp.Bamboo.Services.Build.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<BuildListResponse, BuildResponse>))]
    [JsonRootElementPath("results")]
    [JsonListContentPath("results.result.[*]")]
    public sealed class BuildListResponse : ListResponseBase<BuildResponse>
    {
    }
}