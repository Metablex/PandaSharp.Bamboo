using Newtonsoft.Json;
using PandaSharp.Bamboo.Services.Common.Response.Converter;
using PandaSharp.Framework.Attributes;

namespace PandaSharp.Bamboo.Services.Common.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<LabelListResponse, LabelResponse>))]
    [JsonRootElementPath("labels")]
    [JsonListContentPath("labels.label.[*]")]
    public sealed class LabelListResponse : ListResponseBase<LabelResponse>
    {
    }
}