using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.Bamboo.Services.Common
{
    internal sealed class CommonModule : IPandaContainerModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IBambooApi, BambooApi>();
            container.RegisterType<IResultCountParameterAspect, ResultCountParameterAspect>();
        }
    }
}