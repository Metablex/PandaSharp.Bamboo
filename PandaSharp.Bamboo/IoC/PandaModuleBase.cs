using PandaSharp.Bamboo.IoC.Contract;

namespace PandaSharp.Bamboo.IoC
{
    internal abstract class PandaModuleBase
    {
        public abstract void RegisterModule(IPandaContainer container);
    }
}