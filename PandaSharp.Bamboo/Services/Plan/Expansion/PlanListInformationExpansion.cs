using PandaSharp.Bamboo.Services.Common.Expansion;

namespace PandaSharp.Bamboo.Services.Plan.Expansion
{
    internal sealed class PlanListInformationExpansion : RequestExpansionBase, IPlanListInformationExpansion
    {
        public PlanListInformationExpansion(string expansionRoot)
            : base(expansionRoot)
        {
        }

        public void IncludeActions()
        {
            AddExpansionLevel("actions");
        }

        public void IncludeStages()
        {
            AddExpansionLevel("stages");
        }

        public void IncludeBranches()
        {
            AddExpansionLevel("branches");
        }
    }
}