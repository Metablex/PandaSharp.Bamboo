using PandaSharp.IoC;
using PandaSharp.IoC.Contract;
using PandaSharp.Rest.Common;
using PandaSharp.Rest.Contract;

namespace PandaSharp.Rest
{
    internal sealed class RestModule : PandaModuleBase
    {
        public override void RegisterModule(IPandaContainer container)
        {
            container.RegisterSingletonType<IBambooOptions, BambooOptions>();
            container.RegisterSingletonType<IRestFactory, RestFactory>();
        }
    }
}
