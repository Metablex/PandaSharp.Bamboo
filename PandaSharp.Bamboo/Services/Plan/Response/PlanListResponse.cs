using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;
using PandaSharp.Framework.Services.Response;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<PlanListResponse, PlanResponse>))]
    [JsonRootElementPath("plans")]
    [JsonListContentPath("plans.plan.[*]")]
    public sealed class PlanListResponse : ListResponseBase<PlanResponse>
    {
    }
}
