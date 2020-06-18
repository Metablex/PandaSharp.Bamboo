namespace PandaSharp.Bamboo.Services.Plan.Expansion
{
    public interface IPlanInformationExpansion
    {
        void IncludeActions();

        void IncludeStages();

        void IncludeBranches();

        void IncludeVariableContext();
    }
}