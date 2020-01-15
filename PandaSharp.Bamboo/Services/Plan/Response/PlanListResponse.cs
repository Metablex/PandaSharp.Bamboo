using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<PlanListResponse, PlanResponse>))]
    [JsonItems("plan")]
    [JsonRootElement("plans")]
    public sealed class PlanListResponse : ListResponseBase<PlanResponse>
    {
    }
}
