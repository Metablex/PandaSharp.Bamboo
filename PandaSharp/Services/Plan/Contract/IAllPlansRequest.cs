using PandaSharp.Services.Common.Contract;
using PandaSharp.Services.Plan.Response;

namespace PandaSharp.Services.Plan.Contract
{
    public interface IAllPlansRequest : IRequestBase<PlanListResponse>
    {
        IAllPlansRequest WithMaxResult(int maxResult);

        IAllPlansRequest StartAtIndex(int startIndex);

        IAllPlansRequest IncludeDetails();

        IAllPlansRequest IncludeActions();

        IAllPlansRequest IncludeStages();

        IAllPlansRequest IncludeBranches();
    }
}
