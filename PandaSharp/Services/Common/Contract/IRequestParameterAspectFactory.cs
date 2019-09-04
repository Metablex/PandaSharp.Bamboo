using System;
using System.Collections.Generic;

namespace PandaSharp.Services.Common.Contract
{
    internal interface IRequestParameterAspectFactory
    {
        IList<IRequestParameterAspect> GetParameterAspects(Type type);
    }
}