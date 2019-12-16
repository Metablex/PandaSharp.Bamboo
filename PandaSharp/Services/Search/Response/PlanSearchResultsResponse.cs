using Newtonsoft.Json;
using PandaSharp.Attributes;
using PandaSharp.Services.Common.Response;
using PandaSharp.Services.Search.Response.Converter;

namespace PandaSharp.Services.Search.Response
{
    [JsonConverter(typeof(SearchResultListRootElementResponseConverter))]
    [JsonItems("searchResults")]
    public sealed class PlanSearchResultsResponse : ListResponseBase<PlanSearchResultResponse>
    {
    }
}