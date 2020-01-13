using System.Collections.Generic;

namespace PandaSharp.Bamboo.Services.Build.Contract
{
    internal interface ILabelFilterParameterAspect
    {
        IList<string> Labels { get; set; }
    }
}