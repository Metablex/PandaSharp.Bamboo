using PandaSharp.Bamboo.Services.Common.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Project.Aspect
{
    internal sealed class GetInformationOfRequestAspect : RequestParameterAspectBase, IGetInformationOfRequestAspect
    {
        public bool IncludePlanInformation { get; set; }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            if (IncludePlanInformation)
            {
                restRequest.AddParameter("expand", "plans");
            }
        }
    }
}