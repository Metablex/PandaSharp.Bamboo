using PandaSharp.Bamboo.Services.Common.Expansion;

namespace PandaSharp.Bamboo.Services.Plan.Expansion
{
    internal sealed class PlanInformationExpansion : RequestExpansionBase, IPlanInformationExpansion
    {
        public PlanInformationExpansion(string expansionRoot)
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

        public void IncludeVariableContext()
        {
            AddExpansionLevel("variableContext");
        }
    }
}