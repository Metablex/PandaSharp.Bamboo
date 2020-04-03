using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<PlanListResponse, PlanResponse>))]
    [JsonRootElementPath("plans")]
    [JsonListContentPath("plans.plan.[*]")]
    public sealed class PlanListResponse : ListResponseBase<PlanResponse>
    {
    }
}
