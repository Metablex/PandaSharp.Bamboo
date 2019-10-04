using System;
using PandaSharp.Services.Plan.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class BuildResponse
    {
        [DeserializeAs(Name = "buildNumber")]
        public uint BuildNumber { get; set; }

        [DeserializeAs(Name = "buildState")]
        public string BuildState { get; set; }

        [DeserializeAs(Name = "lifeCycleState")]
        public string LifeCycleState { get; set; }

        [DeserializeAs(Name = "buildResultKey")]
        public string BuildKey { get; set; }

        [DeserializeAs(Name = "successfulTestCount")]
        public uint? SuccessfulTestCount { get; set; }

        [DeserializeAs(Name = "failedTestCount")]
        public uint? FailedTestCount { get; set; }

        [DeserializeAs(Name = "skippedTestCount")]
        public uint? SkippedTestCount { get; set; }

        [DeserializeAs(Name = "buildDurationInSeconds")]
        public uint? BuildDurationInSeconds { get; set; }

        [DeserializeAs(Name = "buildStartedTime")]
        public DateTime? BuildStartedTime { get; set; }

        [DeserializeAs(Name = "buildCompletedTime")]
        public DateTime? BuildCompletedTime { get; set; }

        [DeserializeAs(Name = "plan")]
        public PlanResponse Plan { get; set; }

        [DeserializeAs(Name = "artifacts")]
        public ArtifactsResponse Artifacts { get; set; }

        [DeserializeAs(Name = "comments")]
        public CommentsResponse Comments { get; set; }

        [DeserializeAs(Name = "labels")]
        public LabelsResponse Labels { get; set; }

        [DeserializeAs(Name = "jiraIssues")]
        public JiraIssuesResponse JiraIssues { get; set; }

        [DeserializeAs(Name = "variables")]
        public VariablesResponse Variables { get; set; }

        [DeserializeAs(Name = "stages")]
        public StagesResponse Stages { get; set; }

        [DeserializeAs(Name = "changes")]
        public ChangesResponse Changes { get; set; }

        [DeserializeAs(Name = "metadata")]
        public MetadatasResponse MetaData { get; set; }
    }
}