using Newtonsoft.Json;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;
using PandaSharp.Framework.Attributes;

namespace PandaSharp.Bamboo.Services.Search.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<PlanSearchResultListResponse, PlanSearchResultResponse>))]
    [JsonListContentPath("searchResults[*].searchEntity")]
    public sealed class PlanSearchResultListResponse : ListResponseBase<PlanSearchResultResponse>
    {
    }
}