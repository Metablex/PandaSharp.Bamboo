using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;
using PandaSharp.Framework.Services.Response;

namespace PandaSharp.Bamboo.Services.Search.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<PlanSearchResultListResponse, PlanSearchResultResponse>))]
    [JsonListContentPath("searchResults[*].searchEntity")]
    public sealed class PlanSearchResultListResponse : ListResponseBase<PlanSearchResultResponse>
    {
    }
}