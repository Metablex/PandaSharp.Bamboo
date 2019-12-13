using PandaSharp.IoC.Contract;

namespace PandaSharp.IoC
{
    internal abstract class PandaModuleBase
    {
        public abstract void RegisterModule(IPandaContainer container);
    }
}