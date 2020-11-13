using System;
using PandaSharp.Bamboo.Services.Build.Expansion;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Aspect
{
    internal sealed class GetInformationOfBuildParameterAspect : RequestParameterAspectBase, IGetInformationOfBuildParameterAspect
    {
        private BuildInformationExpansion _buildInformationExpansion;

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            if (_buildInformationExpansion != null)
            {
                restRequest.AddParameterIfSet("expand", _buildInformationExpansion.ToString());
            }
        }

        public void IncludeBuildInformation(params Action<IBuildInformationExpansion>[] expansions)
        {
            _buildInformationExpansion = new BuildInformationExpansion();
            foreach (var expansion in expansions)
            {
                expansion(_buildInformationExpansion);
            }
        }
    }
}