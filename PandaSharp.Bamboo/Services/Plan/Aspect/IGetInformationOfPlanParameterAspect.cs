using System;
using PandaSharp.Bamboo.Services.Plan.Expansion;

namespace PandaSharp.Bamboo.Services.Plan.Aspect
{
    internal interface IGetInformationOfPlanParameterAspect
    {
        void IncludePlanInformation(params Action<IPlanInformationExpansion>[] expansions);
    }
}