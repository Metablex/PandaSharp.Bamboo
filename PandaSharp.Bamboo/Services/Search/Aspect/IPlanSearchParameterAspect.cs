namespace PandaSharp.Bamboo.Services.Search.Aspect
{
    internal interface IPlanSearchParameterAspect
    {
        void SetSearchTerm(string searchTerm);
        
        void SetPerformFuzzySearch(bool performFuzzySearch);
    }
}