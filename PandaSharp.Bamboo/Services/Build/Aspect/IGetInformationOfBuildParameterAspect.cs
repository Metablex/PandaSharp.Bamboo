using System;
using PandaSharp.Bamboo.Services.Build.Expansion;

namespace PandaSharp.Bamboo.Services.Build.Aspect
{
    internal interface IGetInformationOfBuildParameterAspect
    {
        void IncludeBuildInformation(params Action<IBuildInformationExpansion>[] expansions);
    }
}