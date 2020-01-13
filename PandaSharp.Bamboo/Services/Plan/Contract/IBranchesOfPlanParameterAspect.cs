namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    internal interface IBranchesOfPlanParameterAspect
    {
        bool OnlyEnabledBranches { get; set; }
    }
}