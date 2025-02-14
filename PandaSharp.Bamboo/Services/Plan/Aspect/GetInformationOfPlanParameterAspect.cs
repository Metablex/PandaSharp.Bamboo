using System;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Aspect
{
    internal sealed class GetInformationOfPlanParameterAspect : RequestParameterAspectBase, IGetInformationOfPlanParameterAspect
    {
        private PlanInformationExpansion _planInformationExpansion;

        public override void ApplyToRestRequest(RestRequest restRequest)
        {
            if (_planInformationExpansion != null)
            {
                restRequest.AddParameterIfSet("expand", _planInformationExpansion.ToString());
            }
        }

        public void IncludePlanInformation(params Action<IPlanInformationExpansion>[] expansions)
        {
            _planInformationExpansion = new PlanInformationExpansion();
            foreach (var expansion in expansions)
            {
                expansion(_planInformationExpansion);
            }
        }
    }
}
