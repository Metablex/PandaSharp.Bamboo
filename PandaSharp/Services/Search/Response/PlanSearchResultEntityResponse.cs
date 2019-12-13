using RestSharp.Deserializers;

namespace PandaSharp.Services.Search.Response
{
    public sealed class PlanSearchResultEntityResponse
    {
        [DeserializeAs(Name = "key")]
        public string FullPlanKey { get; set; }

        [DeserializeAs(Name = "projectName")]
        public string ProjectName { get; set; }

        [DeserializeAs(Name = "planName")]
        public string PlanName { get; set; }

        [DeserializeAs(Name = "branchName")]
        public string BranchName { get; set; }

        [DeserializeAs(Name = "description")]
        public string Description { get; set; }
    }
}