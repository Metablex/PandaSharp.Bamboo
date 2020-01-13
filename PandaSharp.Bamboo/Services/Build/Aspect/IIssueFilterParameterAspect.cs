using System.Collections.Generic;

namespace PandaSharp.Bamboo.Services.Build.Aspect
{
    internal interface IIssueFilterParameterAspect
    {
        IList<string> Issues { get; set; }
    }
}