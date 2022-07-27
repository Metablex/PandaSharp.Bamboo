using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;
using PandaSharp.Framework.Services.Response;

namespace PandaSharp.Bamboo.Services.Common.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<LabelListResponse, LabelResponse>))]
    [JsonRootElementPath("labels")]
    [JsonListContentPath("labels.label.[*]")]
    public sealed class LabelListResponse : ListResponseBase<LabelResponse>
    {
    }
}