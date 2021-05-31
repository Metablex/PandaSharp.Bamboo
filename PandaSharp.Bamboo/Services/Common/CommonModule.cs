using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.Bamboo.Services.Common
{
    internal sealed class CommonModule : IPandaCoreModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IResultCountParameterAspect, ResultCountParameterAspect>();
        }
    }
}