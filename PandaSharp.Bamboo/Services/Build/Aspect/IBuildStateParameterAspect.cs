using PandaSharp.Bamboo.Services.Build.Types;

namespace PandaSharp.Bamboo.Services.Build.Aspect
{
    internal interface IBuildStateParameterAspect
    {
        BuildState? BuildState { get; set; }
    }
}