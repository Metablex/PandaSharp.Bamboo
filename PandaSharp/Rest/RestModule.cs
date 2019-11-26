using PandaSharp.IoC.Contract;
using PandaSharp.Rest.Common;
using PandaSharp.Rest.Contract;

namespace PandaSharp.Rest
{
    internal static class RestModule
    {
        public static void RegisterRestModule(this IPandaContainer container, string baseUrl, string userName, string password)
        {
            container.RegisterSingletonType<IBambooOptions>(() => new BambooOptions(baseUrl, userName, password));
            container.RegisterSingletonType<IRestFactory, RestFactory>();
        }
    }
}
