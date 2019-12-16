using PandaSharp.Services.Common.Response.Converter;

namespace PandaSharp.Services.Plan.Response.Converter
{
    internal  sealed class PlanListRootElementResponseConverter : RootElementResponseConverterBase<PlanListResponse, PlanResponse>
    {
        protected override string RootElement => "plans";
    }
}