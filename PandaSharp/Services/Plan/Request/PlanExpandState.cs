using PandaSharp.Utils;

namespace PandaSharp.Services.Plan.Request
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
