using System.Collections.Generic;

namespace PandaSharp.Bamboo.Services.Build.Aspect
{
    internal interface IIssueFilterParameterAspect
    {
        void SetIssuesFilter(IList<string> issues);
    }
}