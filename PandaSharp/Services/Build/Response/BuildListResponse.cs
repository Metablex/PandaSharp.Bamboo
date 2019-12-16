using Newtonsoft.Json;
using PandaSharp.Attributes;
using PandaSharp.Services.Build.Response.Converter;
using PandaSharp.Services.Common.Response;

namespace PandaSharp.Services.Build.Response
{
    [JsonConverter(typeof(BuildListRootElementResponseConverter))]
    [JsonItems("result")]
    public sealed class BuildListResponse : ListResponseBase<BuildResponse>
    {
    }
}