using PandaSharp.Services.Common.Aspect;
using PandaSharp.Services.Common.Contract;
using Unity;

namespace PandaSharp.Services
{
    public static class ServicesModule
    {
        public static void RegisterServicesModule(this IUnityContainer container)
        {
            container.RegisterType<IRequestParameterAspectFactory, RequestParameterAspectFactory>();
            container.RegisterType<IResultCountParameterAspect, ResultCountParameterAspect>();
        }
    }
}