using System;
using System.Collections.Generic;

namespace PandaSharp.Bamboo.Services.Common.Aspect
{
    internal interface IRequestParameterAspectFactory
    {
        IList<IRequestParameterAspect> GetParameterAspects(Type type);
    }
}