using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PandaSharp.Bamboo.Services.Common.Response.Converter;
using PandaSharp.Bamboo.Services.Plan.Response;

namespace PandaSharp.Bamboo.Services.Build.Response
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

        [JsonConverter(typeof(JsonListResponseConverter<ArtifactResponse>), "artifact")]
        [JsonProperty("artifacts")]
        public List<ArtifactResponse> Artifacts { get; set; }

        [JsonConverter(typeof(JsonListResponseConverter<CommentResponse>), "comment")]
        [JsonProperty("comments")]
        public List<CommentResponse> Comments { get; set; }

        [JsonConverter(typeof(JsonListResponseConverter<LabelResponse>), "label")]
        [JsonProperty("labels")]
        public List<LabelResponse> Labels { get; set; }

        [JsonConverter(typeof(JsonListResponseConverter<JiraIssueResponse>), "issue")]
        [JsonProperty("jiraIssues")]
        public List<JiraIssueResponse> JiraIssues { get; set; }

        [JsonConverter(typeof(JsonListResponseConverter<VariableResponse>), "variable")]
        [JsonProperty("variables")]
        public List<VariableResponse> Variables { get; set; }

        [JsonConverter(typeof(JsonListResponseConverter<StageResponse>), "stage")]
        [JsonProperty("stages")]
        public List<StageResponse> Stages { get; set; }

        [JsonConverter(typeof(JsonListResponseConverter<ChangeResponse>), "change")]
        [JsonProperty("changes")]
        public List<ChangeResponse> Changes { get; set; }

        [JsonConverter(typeof(JsonListResponseConverter<MetadataResponse>), "item")]
        [JsonProperty("metadata")]
        public List<MetadataResponse> MetaData { get; set; }
    }
}