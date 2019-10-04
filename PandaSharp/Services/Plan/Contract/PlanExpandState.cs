using System;
using PandaSharp.Attributes;

namespace PandaSharp.Services.Plan.Contract
{
    [Flags]
    internal enum PlanExpandState
    {
        [StringRepresentation("actions")]
        IncludingActions = 1 << 0,

        [StringRepresentation("stages")]
        IncludingStages = 1 << 1,

        [StringRepresentation("branches")]
        IncludingBranches = 1 << 2,

        [StringRepresentation("variableContext")]
        IncludingVariableContext = 1 << 3
    }
}