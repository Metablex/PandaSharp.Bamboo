using PandaSharp.Bamboo.IoC;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;

namespace PandaSharp.Bamboo.Services
{
    internal sealed class ServicesModule : PandaModuleBase
    {
        public override void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IRequestParameterAspectFactory, RequestParameterAspectFactory>();
            container.RegisterType<IResultCountParameterAspect, ResultCountParameterAspect>();
        }
    }
}