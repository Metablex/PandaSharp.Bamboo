using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Common.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<LabelListResponse, LabelResponse>))]
    [JsonItems("label")]
    [JsonRootElement("labels")]
    public sealed class LabelListResponse : ListResponseBase<LabelResponse>
    {
    }
}