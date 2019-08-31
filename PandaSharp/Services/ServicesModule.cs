using PandaSharp.Services.Common.Aspect;
using PandaSharp.Utils;
using Unity;

namespace PandaSharp.Services
{
    public static class ServicesModule
    {
        public static void RegisterServicesModule(this IUnityContainer container)
        {
            container.RegisterParameterAspect<ResultCountParameterAspect>();
        }
    }
}