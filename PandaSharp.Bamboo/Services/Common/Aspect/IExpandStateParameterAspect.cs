using System;

namespace PandaSharp.Bamboo.Services.Common.Aspect
{
    internal interface IExpandStateParameterAspect<in T>
        where T : struct, Enum
    {
        void AddExpandState(T state);
    }
}