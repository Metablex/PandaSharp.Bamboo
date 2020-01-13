using System.Collections.Generic;

namespace PandaSharp.Bamboo.Services.Build.Aspect
{
    internal interface ILabelFilterParameterAspect
    {
        IList<string> Labels { get; set; }
    }
}