using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Rest;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Rest.Contract;

namespace PandaSharp.Bamboo.Services.Common
{
    internal sealed class CommonModule : IPandaContainerModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IBambooApi, BambooApi>();
            container.RegisterType<IRestResponseConverter, RestResponseConverter>();
            container.RegisterType<IResultCountParameterAspect, ResultCountParameterAspect>();
        }
    }
}