using System;
using PandaSharp.IoC.Contract;
using PandaSharp.Services.Common.Aspect;
using PandaSharp.Services.Common.Contract;

namespace PandaSharp.Utils
{
    internal static class UnityContainerExtensions
    {
        public static void RegisterExpandStateParameterAspect<T>(this IPandaContainer container)
            where T : struct, Enum
        {
            container.RegisterType<IExpandStateParameterAspect<T>, ExpandStateParameterAspect<T>>();
        }
    }
}