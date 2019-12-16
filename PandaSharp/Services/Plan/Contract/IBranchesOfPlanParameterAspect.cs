namespace PandaSharp.Services.Plan.Contract
{
    internal interface IBranchesOfPlanParameterAspect
    {
        bool OnlyEnabledBranches { get; set; }
    }
}