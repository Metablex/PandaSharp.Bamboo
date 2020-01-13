using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Build.Response.Converter;
using PandaSharp.Bamboo.Services.Common.Response;

namespace PandaSharp.Bamboo.Services.Build.Response
{
    [JsonConverter(typeof(BuildListRootElementResponseConverter))]
    [JsonItems("result")]
    public sealed class BuildListResponse : ListResponseBase<BuildResponse>
    {
    }
}