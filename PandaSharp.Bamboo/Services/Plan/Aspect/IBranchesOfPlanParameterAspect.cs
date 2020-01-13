namespace PandaSharp.Bamboo.Services.Plan.Aspect
{
    internal interface IBranchesOfPlanParameterAspect
    {
        bool OnlyEnabledBranches { get; set; }
    }
}