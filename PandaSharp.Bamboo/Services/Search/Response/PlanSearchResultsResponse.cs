using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Search.Response.Converter;

namespace PandaSharp.Bamboo.Services.Search.Response
{
    [JsonConverter(typeof(SearchResultListRootElementResponseConverter))]
    [JsonItems("searchResults")]
    public sealed class PlanSearchResultsResponse : ListResponseBase<PlanSearchResultResponse>
    {
    }
}