using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Common.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<LabelListResponse, LabelResponse>))]
    [JsonRootElementPath("labels")]
    [JsonListContentPath("labels.label.[*]")]
    public sealed class LabelListResponse : ListResponseBase<LabelResponse>
    {
    }
}