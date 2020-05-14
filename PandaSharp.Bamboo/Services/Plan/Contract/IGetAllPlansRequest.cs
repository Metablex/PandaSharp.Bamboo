using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Plan.Response;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IGetAllPlansRequest : IRequestBase<PlanListResponse>
    {
        IGetAllPlansRequest WithMaxResult(int maxResult);

        IGetAllPlansRequest StartAtIndex(int startIndex);

        IGetAllPlansRequest IncludeDetails();

        IGetAllPlansRequest IncludeActions();

        IGetAllPlansRequest IncludeStages();

        IGetAllPlansRequest IncludeBranches();
    }
}
