namespace PandaSharp.Bamboo.Services.Plan.Aspect
{
    internal interface IGetBranchesOfPlanParameterAspect
    {
        void SetOnlyEnabledBranchesFilter(bool onlyEnabledBranches);
    }
}