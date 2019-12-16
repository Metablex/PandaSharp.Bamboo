using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PandaSharp.Services.Build.Response.Converter;
using PandaSharp.Services.Plan.Response;

namespace PandaSharp.Services.Build.Response
{
    public sealed class BuildResponse
    {
        [JsonProperty("buildNumber")]
        public uint BuildNumber { get; set; }

        [JsonProperty("buildState")]
        public string BuildState { get; set; }

        [JsonProperty("lifeCycleState")]
        public string LifeCycleState { get; set; }

        [JsonProperty("buildResultKey")]
        public string BuildKey { get; set; }

        [JsonProperty("successfulTestCount")]
        public uint? SuccessfulTestCount { get; set; }

        [JsonProperty("failedTestCount")]
        public uint? FailedTestCount { get; set; }

        [JsonProperty("skippedTestCount")]
        public uint? SkippedTestCount { get; set; }

        [JsonProperty("buildDurationInSeconds")]
        public uint? BuildDurationInSeconds { get; set; }

        [JsonProperty("buildStartedTime")]
        public DateTime? BuildStartedTime { get; set; }

        [JsonProperty("buildCompletedTime")]
        public DateTime? BuildCompletedTime { get; set; }

        [JsonProperty("plan")]
        public PlanResponse Plan { get; set; }

        [JsonProperty("artifacts")]
        [JsonConverter(typeof(ArtifactListResponseConverter))]
        public List<ArtifactResponse> Artifacts { get; set; }

        [JsonProperty("comments")]
        [JsonConverter(typeof(CommentListResponseConverter))]
        public List<CommentResponse> Comments { get; set; }

        [JsonProperty("labels")]
        [JsonConverter(typeof(LabelListResponseConverter))]
        public List<LabelResponse> Labels { get; set; }

        [JsonProperty("jiraIssues")]
        [JsonConverter(typeof(JiraIssueListResponseConverter))]
        public List<JiraIssueResponse> JiraIssues { get; set; }

        [JsonProperty("variables")]
        [JsonConverter(typeof(VariableListResponseConverter))]
        public List<VariableResponse> Variables { get; set; }

        [JsonProperty("stages")]
        [JsonConverter(typeof(StageListResponseConverter))]
        public List<StageResponse> Stages { get; set; }

        [JsonProperty("changes")]
        [JsonConverter(typeof(ChangeListResponseConverter))]
        public List<ChangeResponse> Changes { get; set; }

        [JsonProperty("metadata")]
        [JsonConverter(typeof(MetadataListResponseConverter))]
        public List<MetadataResponse> MetaData { get; set; }
    }
}