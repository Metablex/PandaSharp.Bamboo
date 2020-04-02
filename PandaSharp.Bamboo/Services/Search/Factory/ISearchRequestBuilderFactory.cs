using PandaSharp.Bamboo.Services.Search.Contract;

namespace PandaSharp.Bamboo.Services.Search.Factory
{
    public interface ISearchRequestBuilderFactory
    {
        ISearchForPlansRequest SearchForPlans();
    }
}