using PandaSharp.Bamboo.Services.Search.Aspect;
using PandaSharp.Bamboo.Services.Search.Contract;
using PandaSharp.Bamboo.Services.Search.Factory;
using PandaSharp.Bamboo.Services.Search.Request;
using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.Bamboo.Services.Search
{
    internal sealed class SearchModule : IPandaContainerModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<ISearchForPlansRequest, SearchForPlansRequest>();
            container.RegisterType<IPlanSearchParameterAspect, PlanSearchParameterAspect>();
            container.RegisterType<ISearchRequestBuilderFactory, SearchRequestBuilderFactory>();
        }
    }
}