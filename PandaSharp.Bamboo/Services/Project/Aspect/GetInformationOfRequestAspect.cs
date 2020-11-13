using System;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Project.Aspect
{
    internal sealed class GetInformationOfRequestAspect : RequestParameterAspectBase, IGetInformationOfRequestAspect
    {
        private PlanListInformationExpansion _planListInformationExpansion;

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            if (_planListInformationExpansion != null)
            {
                restRequest.AddParameter("expand", _planListInformationExpansion.ToString());
            }
        }

        public void IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions)
        {
            _planListInformationExpansion = new PlanListInformationExpansion("plans.plan");
            foreach (var expansion in expansions)
            {
                expansion(_planListInformationExpansion);
            }
        }
    }
}