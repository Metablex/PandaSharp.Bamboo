using System;
using PandaSharp.Services.Common.Aspect;
using PandaSharp.Services.Common.Contract;
using Unity;

namespace PandaSharp.Utils
{
    internal static class UnityContainerExtensions
    {
        public static void RegisterExpandStateParameterAspect<T>(this IUnityContainer container)
            where T : struct, Enum
        {
            container.RegisterType<IExpandStateParameterAspect<T>, ExpandStateParameterAspect<T>>();
        }
    }
}