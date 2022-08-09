namespace PandaSharp.Bamboo.Services.Plan.Aspect
{
    internal interface ICreatePlanParameterAspect
    {
        void SetVcsBranchFilter(string vcsBranch);
        
        void SetIsEnabledFilter(bool isEnabled);
        
        void SetIsCleanupEnabledFilter(bool isCleanupEnabled);
    }
}