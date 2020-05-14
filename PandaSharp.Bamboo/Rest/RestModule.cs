using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Rest.Common;
using PandaSharp.Bamboo.Rest.Contract;
using RestSharp.Serialization;

namespace PandaSharp.Bamboo.Rest
{
    internal sealed class RestModule : IPandaCoreModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterSingletonType<IBambooOptions, BambooOptions>();
            container.RegisterSingletonType<IRestSerializer, RestRequestSerializer>();
            container.RegisterSingletonType<IRestFactory, RestFactory>();
        }
    }
}
