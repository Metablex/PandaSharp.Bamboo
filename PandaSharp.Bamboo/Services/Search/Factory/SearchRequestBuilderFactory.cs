using PandaSharp.Bamboo.Services.Search.Contract;
using PandaSharp.Bamboo.Services.Search.Request;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Rest.Common;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;

namespace PandaSharp.Bamboo.Services.Search.Factory
{
    internal sealed class SearchRequestBuilderFactory : ISearchRequestBuilderFactory
    {
        private readonly IPandaContainer _container;

        public SearchRequestBuilderFactory(IPandaContainer container)
        {
            _container = container;
        }

        public ISearchForPlansRequest SearchForPlans()
        {
            var restFactory = CreateRestFactory();

            return new SearchForPlansRequest(
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        private IRestFactory CreateRestFactory()
        {
            return new RestFactory(_container.Resolve<IRestOptions>(), JsonRestSerializer.Default);
        }
    }
}
