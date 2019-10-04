namespace PandaSharp.Services.Build.Contract
{
    internal interface IBuildStateParameterAspect
    {
        BuildState? BuildState { get; set; }
    }
}