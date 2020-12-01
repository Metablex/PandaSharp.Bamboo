using System;
using PandaSharp.Bamboo.Services.Plan.Expansion;

namespace PandaSharp.Bamboo.Services.Project.Aspect
{
    internal interface IGetInformationOfProjectRequestAspect
    {
        void IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions);
    }
}