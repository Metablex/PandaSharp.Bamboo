using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Build.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<BuildListResponse, BuildResponse>))]
    [JsonItems("result")]
    [JsonRootElement("results")]
    public sealed class BuildListResponse : ListResponseBase<BuildResponse>
    {
    }
}