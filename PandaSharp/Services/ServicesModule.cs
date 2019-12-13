using PandaSharp.IoC;
using PandaSharp.IoC.Contract;
using PandaSharp.Services.Common.Aspect;
using PandaSharp.Services.Common.Contract;

namespace PandaSharp.Services
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