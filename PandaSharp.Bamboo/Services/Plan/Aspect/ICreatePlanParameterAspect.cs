namespace PandaSharp.Bamboo.Services.Plan.Aspect
{
    internal interface ICreatePlanParameterAspect
    {
        string VcsBranch { get; set; }

        bool? IsEnabled { get; set; }

        bool? IsCleanupEnabled { get; set; }
    }
}