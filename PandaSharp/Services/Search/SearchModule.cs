using PandaSharp.IoC;
using PandaSharp.IoC.Contract;
using PandaSharp.Services.Search.Aspect;
using PandaSharp.Services.Search.Contract;
using PandaSharp.Services.Search.Factory;
using PandaSharp.Services.Search.Request;

namespace PandaSharp.Services.Search
{
    internal sealed class SearchModule : PandaModuleBase
    {
        public override void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IPlanSearchRequest, PlanSearchRequest>();
            container.RegisterType<IPlanSearchParameterAspect, PlanSearchParameterAspect>();
            container.RegisterType<ISearchRequestBuilderFactory, SearchRequestBuilderFactory>();
        }
    }
}