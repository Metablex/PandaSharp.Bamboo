using Newtonsoft.Json;
using PandaSharp.Attributes;
using PandaSharp.Services.Common.Response;
using PandaSharp.Services.Plan.Response.Converter;

namespace PandaSharp.Services.Plan.Response
{
    [JsonConverter(typeof(BranchListRootElementResponseConverter))]
    [JsonItems("branch")]
    public sealed class BranchListResponse : ListResponseBase<BranchResponse>
    {
    }
}