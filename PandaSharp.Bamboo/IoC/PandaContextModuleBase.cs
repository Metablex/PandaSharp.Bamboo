using PandaSharp.Bamboo.IoC.Contract;

namespace PandaSharp.Bamboo.IoC
{
    internal abstract class PandaContextModuleBase
    {
        public abstract void RegisterModule(IPandaContainer container, PandaContainerContext context);
    }
}