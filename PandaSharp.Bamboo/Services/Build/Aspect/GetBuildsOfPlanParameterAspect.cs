using System;
using PandaSharp.Bamboo.Services.Build.Expansion;
using PandaSharp.Framework.Services.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Aspect
{
    internal sealed class GetBuildsOfPlanParameterAspect : RequestParameterAspectBase, IGetBuildsOfPlanParameterAspect
    {
        private BuildListInformationExpansion _buildListInformationExpansion;

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            if (_buildListInformationExpansion != null)
            {
                restRequest.AddParameter("expand", _buildListInformationExpansion.ToString());
            }
        }

        public void IncludeBuildInformation(params Action<IBuildListInformationExpansion>[] expansions)
        {
            _buildListInformationExpansion = new BuildListInformationExpansion();
            foreach (var expansion in expansions)
            {
                expansion(_buildListInformationExpansion);
            }
        }
    }
}