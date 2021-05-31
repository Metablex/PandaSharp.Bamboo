using System;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Framework.Services.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Project.Aspect
{
    internal sealed class GetAllProjectsParameterAspect : RequestParameterAspectBase, IGetAllProjectsParameterAspect
    {
        private PlanListInformationExpansion _planListInformationExpansion;

        public bool IncludeEmptyProjects { get; set; }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            if (IncludeEmptyProjects)
            {
                restRequest.AddParameter("showEmpty", null);
            }

            var expandState = _planListInformationExpansion?.ToString() ?? "projects.project";
            restRequest.AddParameter("expand", expandState);
        }

        public void IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions)
        {
            _planListInformationExpansion = new PlanListInformationExpansion("projects.project.plans.plan");
            foreach (var expansion in expansions)
            {
                expansion(_planListInformationExpansion);
            }
        }
    }
}