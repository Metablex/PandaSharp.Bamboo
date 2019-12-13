namespace PandaSharp.Services.Search.Contract
{
    public interface ISearchRequestBuilderFactory
    {
        IPlanSearchRequest ForPlans();
    }
}