using System;

namespace PandaSharp.Services.Common.Contract
{
    internal interface IExpandStateParameterAspect<in T>
        where T : struct, Enum
    {
        void AddExpandState(T state);
    }
}