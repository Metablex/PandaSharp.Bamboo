using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;

namespace PandaSharp.Bamboo.Services.Common
{
    internal sealed class CommonModule : IPandaCoreModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IRequestParameterAspectFactory, RequestParameterAspectFactory>();
            container.RegisterType<IResultCountParameterAspect, ResultCountParameterAspect>();
        }
    }
}