using System.Collections.Generic;

namespace PandaSharp.Services.Build.Contract
{
    internal interface IIssueFilterParameterAspect
    {
        IList<string> Issues { get; set; }
    }
}