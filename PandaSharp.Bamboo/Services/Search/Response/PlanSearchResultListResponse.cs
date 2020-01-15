using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Search.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<PlanSearchResultListResponse, PlanSearchResultResponse>))]
    [JsonItems("searchResults")]
    public sealed class PlanSearchResultListResponse : ListResponseBase<PlanSearchResultResponse>
    {
    }
}