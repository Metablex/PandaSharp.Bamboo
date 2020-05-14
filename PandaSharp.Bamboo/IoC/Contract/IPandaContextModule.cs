namespace PandaSharp.Bamboo.IoC.Contract
{
    internal interface IPandaContextModule
    {
        void RegisterModule(IPandaContainer container, PandaContainerContext context);
    }
}