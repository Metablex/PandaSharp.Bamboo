using PandaSharp.IoC.Contract;

namespace PandaSharp.IoC
{
    internal abstract class PandaContextModuleBase
    {
        public abstract void RegisterModule(IPandaContainer container, PandaContainerContext context);
    }
}