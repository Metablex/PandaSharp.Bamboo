using PandaSharp.Bamboo.Services.Search.Contract;
using PandaSharp.Framework.IoC.Contract;

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
            return _container.Resolve<ISearchForPlansRequest>();
        }
    }
}
