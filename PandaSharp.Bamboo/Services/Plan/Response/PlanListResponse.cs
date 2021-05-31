using Newtonsoft.Json;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;
using PandaSharp.Framework.Attributes;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<PlanListResponse, PlanResponse>))]
    [JsonRootElementPath("plans")]
    [JsonListContentPath("plans.plan.[*]")]
    public sealed class PlanListResponse : ListResponseBase<PlanResponse>
    {
    }
}
