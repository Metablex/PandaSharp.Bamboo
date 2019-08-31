using PandaSharp.Rest.Common;
using PandaSharp.Rest.Contract;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace PandaSharp.Rest
{
    internal static class RestModule
    {
        public static void RegisterRestModule(this IUnityContainer container, string baseUrl, string userName, string password)
        {
            container.RegisterType<IBambooOptions, BambooOptions>(new ContainerControlledLifetimeManager(), new InjectionConstructor(baseUrl, userName, password));
            container.RegisterType<IRestFactory, RestFactory>(new ContainerControlledLifetimeManager());
        }
    }
}
