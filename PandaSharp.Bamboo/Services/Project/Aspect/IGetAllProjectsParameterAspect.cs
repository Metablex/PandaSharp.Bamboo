using System;
using PandaSharp.Bamboo.Services.Plan.Expansion;

namespace PandaSharp.Bamboo.Services.Project.Aspect
{
    internal interface IGetAllProjectsParameterAspect
    {
        void SetIncludeEmptyProjects(bool includeEmptyProjects);

        void IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions);
    }
}