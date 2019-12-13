using PandaSharp.IoC.Contract;
using PandaSharp.Services.Search.Contract;

namespace PandaSharp.Services.Search.Factory
{
    internal sealed class SearchRequestBuilderFactory : ISearchRequestBuilderFactory
    {
        private readonly IPandaContainer _container;

        public SearchRequestBuilderFactory(IPandaContainer container)
        {
            _container = container;
        }

        public IPlanSearchRequest ForPlans()
        {
            return _container.Resolve<IPlanSearchRequest>();
        }
    }
}
