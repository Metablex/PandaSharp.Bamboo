using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PandaSharp.Attributes;
using PandaSharp.Rest.Contract;
using PandaSharp.Services.Common.Contract;
using Unity;

namespace PandaSharp.Utils
{
    internal static class UnityContainerExtension
    {
        public static void RegisterRequest<TInterface, TInstance>(this IUnityContainer container)
        {
            container.RegisterFactory<TInterface>(c => CreateRequest<TInterface, TInstance>(c));
        }

        public static void RegisterParameterAspect<TInstance>(this IUnityContainer container)
            where TInstance : IRequestParameterAspect
        {
            container.RegisterType<IRequestParameterAspect, TInstance>(typeof(TInstance).Name);
        }

        private static TInterface CreateRequest<TInterface, TInstance>(IUnityContainer container)
        {
            return (TInterface)Activator.CreateInstance(
                typeof(TInstance),
                container.Resolve<IRestFactory>(),
                ResolveParameterAspects<TInstance>(container));
        }

        private static IList<IRequestParameterAspect> ResolveParameterAspects<TInstance>(IUnityContainer container)
        {
            return typeof(TInstance)
                .GetCustomAttributes(typeof(SupportsParameterAspectAttribute))
                .Cast<SupportsParameterAspectAttribute>()
                .Select(attribute => attribute.ParameterAspectName)
                .Select(aspectName => container.Resolve<IRequestParameterAspect>(aspectName))
                .ToList();
        }
    }
}