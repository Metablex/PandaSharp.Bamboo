namespace PandaSharp.Bamboo.Services.Plan.Aspect
{
    internal interface IGetBranchesOfPlanParameterAspect
    {
        bool OnlyEnabledBranches { get; set; }
    }
}