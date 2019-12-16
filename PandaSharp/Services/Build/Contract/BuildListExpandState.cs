using System;
using PandaSharp.Attributes;

namespace PandaSharp.Services.Build.Contract
{
    [Flags]
    internal enum BuildListExpandState
    {
        [StringRepresentation("results.result")]
        IncludingDetails = 1 << 0,

        [StringRepresentation("results.result.artifacts")]
        IncludingArtifacts = 1 << 1,

        [StringRepresentation("results.result.comments.comment")]
        IncludingComments = 1 << 2,

        [StringRepresentation("results.result.labels")]
        IncludingLabels = 1 << 3,

        [StringRepresentation("results.result.jiraIssues")]
        IncludingJiraIssues = 1 << 4,

        [StringRepresentation("results.result.variables")]
        IncludingVariables = 1 << 5,

        [StringRepresentation("results.result.stages.stage")]
        IncludingStages = 1 << 6
    }
}