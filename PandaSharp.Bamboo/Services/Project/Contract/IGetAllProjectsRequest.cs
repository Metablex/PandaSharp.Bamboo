using System;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Bamboo.Services.Project.Response;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.Bamboo.Services.Project.Contract
{
    public interface IGetAllProjectsRequest : IRequestBase<ProjectListResponse>
    {
        IGetAllProjectsRequest WithMaxResult(int maxResult);

        IGetAllProjectsRequest StartAtIndex(int startIndex);

        IGetAllProjectsRequest IncludeEmptyProjects();

        IGetAllProjectsRequest IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions);
    }
}