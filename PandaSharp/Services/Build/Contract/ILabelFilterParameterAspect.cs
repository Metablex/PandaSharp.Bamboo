using System.Collections.Generic;

namespace PandaSharp.Services.Build.Contract
{
    internal interface ILabelFilterParameterAspect
    {
        IList<string> Labels { get; set; }
    }
}