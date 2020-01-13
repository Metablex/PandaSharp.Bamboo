namespace PandaSharp.Bamboo.Services.Search.Aspect
{
    internal interface IPlanSearchParameterAspect
    {
        string SearchTerm { get; set; }

        bool PerformFuzzySearch { get; set; }
    }
}