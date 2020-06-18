using System;
using PandaSharp.Bamboo.Services.Plan.Expansion;

namespace PandaSharp.Bamboo.Services.Plan.Aspect
{
    internal interface IGetAllPlansParameterAspect
    {
        void IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions);
    }
}