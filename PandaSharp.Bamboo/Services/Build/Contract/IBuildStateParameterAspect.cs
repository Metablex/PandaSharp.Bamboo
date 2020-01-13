namespace PandaSharp.Bamboo.Services.Build.Contract
{
    internal interface IBuildStateParameterAspect
    {
        BuildState? BuildState { get; set; }
    }
}