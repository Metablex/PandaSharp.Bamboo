using PandaSharp.Services.Common.Contract;
using PandaSharp.Services.Plan.Response;

namespace PandaSharp.Services.Plan.Contract
{
    public interface IBranchesOfPlanRequest : IRequestBase<BranchListResponse>
    {
        IBranchesOfPlanRequest WithMaxResult(int maxResult);

        IBranchesOfPlanRequest StartAtIndex(int startIndex);

        IBranchesOfPlanRequest OnlyEnabledBranches();
    }
}