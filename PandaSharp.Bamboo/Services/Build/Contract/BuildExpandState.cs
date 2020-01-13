using System;
using PandaSharp.Bamboo.Attributes;

namespace PandaSharp.Bamboo.Services.Build.Contract
{
    [Flags]
    internal enum BuildExpandState
    {
        [StringRepresentation("artifacts")]
        IncludingArtifacts = 1 << 0,

        [StringRepresentation("comments")]
        IncludingComments = 1 << 1,

        [StringRepresentation("labels")]
        IncludingLabels = 1 << 2,

        [StringRepresentation("jiraIssues")]
        IncludingJiraIssues = 1 << 3,

        [StringRepresentation("variables")]
        IncludingVariables = 1 << 4,

        [StringRepresentation("stages")]
        IncludingStages = 1 << 5,

        [StringRepresentation("changes")]
        IncludingChanges = 1 << 6,

        [StringRepresentation("metadata")]
        IncludingMetaData = 1 << 7
    }
}