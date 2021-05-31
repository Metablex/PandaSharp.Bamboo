using PandaSharp.Bamboo.Services.Search.Aspect;
using PandaSharp.Bamboo.Services.Search.Contract;
using PandaSharp.Bamboo.Services.Search.Factory;
using PandaSharp.Bamboo.Services.Search.Request;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Utils;

namespace PandaSharp.Bamboo.Services.Search
{
    internal sealed class SearchModule : IPandaContextModule
    {
        public void RegisterModule(IPandaContainer container, IPandaContainerContext context)
        {
            container
                .RequestRegistrationFor<ISearchForPlansRequest>()
                .LatestRequest<SearchForPlansRequest>()
                .Register(context);

            container.RegisterType<IPlanSearchParameterAspect, PlanSearchParameterAspect>();

            container.RegisterType<ISearchRequestBuilderFactory, SearchRequestBuilderFactory>();
        }
    }
}