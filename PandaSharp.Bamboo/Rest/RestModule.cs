using PandaSharp.Bamboo.IoC;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Rest.Common;
using PandaSharp.Bamboo.Rest.Contract;
using RestSharp.Deserializers;

namespace PandaSharp.Bamboo.Rest
{
    internal sealed class RestModule : PandaModuleBase
    {
        public override void RegisterModule(IPandaContainer container)
        {
            container.RegisterSingletonType<IBambooOptions, BambooOptions>();
            container.RegisterSingletonType<IDeserializer, RestResponseDeserializer>();
            container.RegisterSingletonType<IRestFactory, RestFactory>();
        }
    }
}
