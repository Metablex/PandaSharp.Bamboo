using RestSharp.Deserializers;

namespace PandaSharp.Services.Plan.Response
{
    public sealed class PlanResponse
    {
        [DeserializeAs(Name = "projectKey")]
        public string ProjectKey { get; set; }

        [DeserializeAs(Name = "projectName")]
        public string ProjectName { get; set; }

        [DeserializeAs(Name = "name")]
        public string LongPlanName { get; set; }

        [DeserializeAs(Name = "shortName")]
        public string ShortPlanName { get; set; }

        [DeserializeAs(Name = "key")]
        public string LongPlanKey { get; set; }

        [DeserializeAs(Name = "shortKey")]
        public string ShortPlanKey { get; set; }

        [DeserializeAs(Name = "enabled")]
        public bool IsEnabled { get; set; }

        [DeserializeAs(Name = "isFavourite")]
        public bool? IsFavourite { get; set; }

        [DeserializeAs(Name = "isActive")]
        public bool? IsActive { get; set; }

        [DeserializeAs(Name = "isBuilding")]
        public bool? IsBuilding { get; set; }

        [DeserializeAs(Name = "actions")]
        public ActionListResponse Actions { get; set; }

        [DeserializeAs(Name = "stages")]
        public StagesListResponse Stages { get; set; }

        [DeserializeAs(Name = "branches")]
        public BranchesListResponse Branches { get; set; }
    }
}