using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Plan.Response;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IBranchesOfPlanRequest : IRequestBase<BranchListResponse>
    {
        IBranchesOfPlanRequest WithMaxResult(int maxResult);

        IBranchesOfPlanRequest StartAtIndex(int startIndex);

        IBranchesOfPlanRequest OnlyEnabledBranches();
    }
}