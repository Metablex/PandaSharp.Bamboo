using System;
using PandaSharp.Bamboo.Services.Build.Expansion;

namespace PandaSharp.Bamboo.Services.Build.Aspect
{
    internal interface IGetBuildsOfPlanParameterAspect
    {
        void IncludeBuildInformation(params Action<IBuildListInformationExpansion>[] expansions);
    }
}