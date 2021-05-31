using System;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Bamboo.Services.Project.Response;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.Bamboo.Services.Project.Contract
{
    public interface IGetInformationOfProjectRequest : IRequestBase<ProjectResponse>
    {
        IGetInformationOfProjectRequest WithMaxResult(int maxResult);

        IGetInformationOfProjectRequest StartAtIndex(int startIndex);

        IGetInformationOfProjectRequest IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions);
    }
}