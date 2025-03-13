using PandaSharp.Bamboo.Services.Search.Aspect;
using PandaSharp.Bamboo.Services.Search.Factory;
using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.Bamboo.Services.Search
{
    internal sealed class SearchModule : IPandaContainerModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IPlanSearchParameterAspect, PlanSearchParameterAspect>();
            container.RegisterType<ISearchRequestBuilderFactory, SearchRequestBuilderFactory>();
        }
    }
}
