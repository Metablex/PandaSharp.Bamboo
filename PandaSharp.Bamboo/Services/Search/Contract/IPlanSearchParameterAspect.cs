namespace PandaSharp.Bamboo.Services.Search.Contract
{
    internal interface IPlanSearchParameterAspect
    {
        string SearchTerm { get; set; }

        bool PerformFuzzySearch { get; set; }
    }
}