using PandaSharp.IoC.Contract;
using PandaSharp.Services.Common.Aspect;
using PandaSharp.Services.Common.Contract;

namespace PandaSharp.Services
{
    internal static class ServicesModule
    {
        public static void RegisterServicesModule(this IPandaContainer container)
        {
            container.RegisterType<IRequestParameterAspectFactory, RequestParameterAspectFactory>();
            container.RegisterType<IResultCountParameterAspect, ResultCountParameterAspect>();
        }
    }
}