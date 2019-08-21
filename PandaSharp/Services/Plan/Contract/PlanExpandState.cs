using PandaSharp.Services.Common;

namespace PandaSharp.Services.Plan.Contract
{
    internal enum PlanExpandState
    {
        [StringRepresentation("plans")]
        OnlyPlans,

        [StringRepresentation("plans.plan")]
        IncludingDetails,

        [StringRepresentation("plans.plan.actions")]
        IncludingDetailsAndActions
    }
}
