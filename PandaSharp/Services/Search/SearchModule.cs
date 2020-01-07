using PandaSharp.IoC;
using PandaSharp.IoC.Contract;
using PandaSharp.Services.Search.Aspect;
using PandaSharp.Services.Search.Contract;
using PandaSharp.Services.Search.Factory;
using PandaSharp.Services.Search.Request;
using PandaSharp.Utils;

namespace PandaSharp.Services.Search
{
    internal sealed class SearchModule : PandaContextModuleBase
    {
        public override void RegisterModule(IPandaContainer container, PandaContainerContext context)
        {
            container
                .RequestRegistrationFor<IPlanSearchRequest>()
                .LatestRequest<PlanSearchRequest>()
                .Register(context);

            container.RegisterType<IPlanSearchParameterAspect, PlanSearchParameterAspect>();

            container.RegisterType<ISearchRequestBuilderFactory, SearchRequestBuilderFactory>();
        }
    }
}