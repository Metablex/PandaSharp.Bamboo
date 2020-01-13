using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response.Converter
{
    internal  sealed class PlanListRootElementResponseConverter : RootElementResponseConverterBase<PlanListResponse, PlanResponse>
    {
        protected override string RootElement => "plans";
    }
}