using System;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Framework.Services.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Project.Aspect
{
    internal sealed class GetAllProjectsParameterAspect : RequestParameterAspectBase, IGetAllProjectsParameterAspect
    {
        private PlanListInformationExpansion _planListInformationExpansion;
        private bool _includeEmptyProjects;

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            if (_includeEmptyProjects)
            {
                restRequest.AddParameter("showEmpty", true);
            }

            var expandState = _planListInformationExpansion?.ToString() ?? "projects.project";
            restRequest.AddParameter("expand", expandState);
        }

        public void SetIncludeEmptyProjects(bool includeEmptyProjects)
        {
            _includeEmptyProjects = includeEmptyProjects;
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