using System;
using PandaSharp.Attributes;

namespace PandaSharp.Services.Plan.Contract
{
    [Flags]
    internal enum PlansExpandState
    {
        [StringRepresentation("plans.plan")]
        IncludingDetails = 1 << 0,

        [StringRepresentation("plans.plan.actions")]
        IncludingActions = 1 << 1,

        [StringRepresentation("plans.plan.stages")]
        IncludingStages = 1 << 2,

        [StringRepresentation("plans.plan.branches")]
        IncludingBranches = 1 << 3
    }
}
