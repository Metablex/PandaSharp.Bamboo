using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using PandaSharp.IoC;
using PandaSharp.IoC.Contract;
using PandaSharp.Rest.Contract;
using PandaSharp.Services.Common.Aspect;
using PandaSharp.Services.Common.Contract;
using PandaSharp.Services.Common.Request;
using RestSharp;

namespace PandaSharp.Utils
{
    internal static class UnityContainerExtensions
    {
        public static void RegisterPandaModules(this IPandaContainer container, Action onAfterCoreModulesRegistered = null)
        {
            var coreModules = GetAllDerivedClassesOf<PandaModuleBase>();
            foreach (var coreModule in coreModules)
            {
                coreModule.RegisterModule(container);
            }

            onAfterCoreModulesRegistered?.Invoke();

            var context = GetPandaContainerContext(container);
            var contextBasedModules = GetAllDerivedClassesOf<PandaContextModuleBase>();
            foreach (var contextBasedModule in contextBasedModules)
            {
                contextBasedModule.RegisterModule(container, context);
            }
        }

        public static IRequestProviderRegistration<T> RequestRegistrationFor<T>(this IPandaContainer container)
        {
            return new RequestProviderRegistration<T>(container);
        }

        public static void RegisterExpandStateParameterAspect<T>(this IPandaContainer container)
            where T : struct, Enum
        {
            container.RegisterType<IExpandStateParameterAspect<T>, ExpandStateParameterAspect<T>>();
        }

        private static PandaContainerContext GetPandaContainerContext(IPandaContainer container)
        {
            var bambooVersion = GetCurrentBambooVersion(container);
            return new PandaContainerContext(bambooVersion);
        }

        private static Version GetCurrentBambooVersion(IPandaContainer container)
        {
            var restFactory = container.Resolve<IRestFactory>();
            var restClient = restFactory.CreateClient();
            var restRequest = restFactory.CreateRequest("info", Method.GET);

            try
            {
                var infoResponse = restClient.Execute(restRequest);
                var jsonResponse = JObject.Parse(infoResponse.Content);
                var version = (string)jsonResponse.SelectToken("version");

                return new Version(version);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Could not retrieve current bamboo version");
            }
        }

        private static IEnumerable<T> GetAllDerivedClassesOf<T>()
        {
            return typeof(T)
                .Assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(T)))
                .Select(Activator.CreateInstance)
                .OfType<T>();
        }
    }
}