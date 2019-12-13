using System;
using System.Linq;
using PandaSharp.IoC;
using PandaSharp.IoC.Contract;
using PandaSharp.Services.Common.Aspect;
using PandaSharp.Services.Common.Contract;

namespace PandaSharp.Utils
{
    internal static class UnityContainerExtensions
    {
        public static void RegisterPandaModules(this IPandaContainer container)
        {
            var modules = typeof(PandaModuleBase)
                .Assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(PandaModuleBase)));

            foreach (var moduleType in modules)
            {
                var module = (PandaModuleBase)Activator.CreateInstance(moduleType);
                module.RegisterModule(container);
            }
        }

        public static void RegisterExpandStateParameterAspect<T>(this IPandaContainer container)
            where T : struct, Enum
        {
            container.RegisterType<IExpandStateParameterAspect<T>, ExpandStateParameterAspect<T>>();
        }
    }
}