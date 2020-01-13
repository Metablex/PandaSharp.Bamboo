using System.Collections.Generic;

namespace PandaSharp.Bamboo.Services.Build.Contract
{
    internal interface IIssueFilterParameterAspect
    {
        IList<string> Issues { get; set; }
    }
}