using PandaSharp.Bamboo.Services.Common.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Project.Aspect
{
    internal sealed class GetAllProjectsParameterAspect : RequestParameterAspectBase, IGetAllProjectsParameterAspect
    {
        public bool IncludeEmptyProjects { get; set; }

        public bool IncludePlanInformation { get; set; }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            if (IncludeEmptyProjects)
            {
                restRequest.AddParameter("showEmpty", null);
            }

            var expandStateValue = "projects.project";
            if (IncludePlanInformation)
            {
                expandStateValue += ".plans";
            }

            restRequest.AddParameter("expand", expandStateValue);
        }
    }
}