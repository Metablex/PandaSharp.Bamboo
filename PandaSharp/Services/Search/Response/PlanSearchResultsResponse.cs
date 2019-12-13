using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Search.Response
{
    public sealed class PlanSearchResultsResponse : ListResponseBase
    {
        [DeserializeAs(Name = "searchResults")]
        public List<PlanSearchResultResponse> SearchResults { get; set; }
    }
}