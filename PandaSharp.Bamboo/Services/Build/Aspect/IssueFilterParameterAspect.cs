using System.Collections.Generic;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Aspect
{
    internal sealed class IssueFilterParameterAspect : RequestParameterAspectBase, IIssueFilterParameterAspect
    {
        public IList<string> Issues { get; set; }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            restRequest.AddParameterValues("issueKey", Issues);
        }
    }
}