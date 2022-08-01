using System.Collections.Generic;

namespace PandaSharp.Bamboo.Services.Build.Aspect
{
    internal interface ILabelFilterParameterAspect
    {
        void SetLabelsFilter(IList<string> labels);
    }
}