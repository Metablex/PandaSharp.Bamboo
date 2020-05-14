using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Project.Response;

namespace PandaSharp.Bamboo.Services.Project.Contract
{
    public interface IGetAllProjectsRequest : IRequestBase<ProjectListResponse>
    {
        IGetAllProjectsRequest WithMaxResult(int maxResult);

        IGetAllProjectsRequest StartAtIndex(int startIndex);

        IGetAllProjectsRequest IncludeEmptyProjects();

        IGetAllProjectsRequest IncludePlanInformation();
    }
}