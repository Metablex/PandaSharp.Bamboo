using Newtonsoft.Json;
using PandaSharp.Attributes;
using PandaSharp.Services.Common.Response;
using PandaSharp.Services.Plan.Response.Converter;

namespace PandaSharp.Services.Plan.Response
{
    [JsonConverter(typeof(PlanListRootElementResponseConverter))]
    [JsonItems("plan")]
    public sealed class PlanListResponse : ListResponseBase<PlanResponse>
    {
    }
}
