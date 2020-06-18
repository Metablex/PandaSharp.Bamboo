using System;
using PandaSharp.Bamboo.Services.Plan.Expansion;

namespace PandaSharp.Bamboo.Services.Project.Aspect
{
    internal interface IGetInformationOfRequestAspect
    {
        void IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions);
    }
}