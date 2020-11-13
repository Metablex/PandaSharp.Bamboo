namespace PandaSharp.Bamboo.Services.Plan.Expansion
{
    public interface IPlanListInformationExpansion
    {
        void IncludeStages();

        void IncludeBranches();

        void IncludeActions();
    }
}