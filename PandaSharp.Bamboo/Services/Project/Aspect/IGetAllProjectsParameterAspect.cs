using System;
using PandaSharp.Bamboo.Services.Plan.Expansion;

namespace PandaSharp.Bamboo.Services.Project.Aspect
{
    internal interface IGetAllProjectsParameterAspect
    {
        bool IncludeEmptyProjects { get; set; }

        void IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions);
    }
}