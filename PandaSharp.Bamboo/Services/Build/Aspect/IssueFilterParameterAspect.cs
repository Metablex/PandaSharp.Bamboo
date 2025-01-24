using System.Collections.Generic;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Aspect
{
    internal sealed class IssueFilterParameterAspect : RequestParameterAspectBase, IIssueFilterParameterAspect
    {
        private IList<string> _issues;

        public void SetIssuesFilter(IList<string> issues)
        {
            _issues = issues;
        }

        public override void ApplyToRestRequest(RestRequest restRequest)
        {
            restRequest.AddParameterValues("issueKey", _issues);
        }
    }
}
