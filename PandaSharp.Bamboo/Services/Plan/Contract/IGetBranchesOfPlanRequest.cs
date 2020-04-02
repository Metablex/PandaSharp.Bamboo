using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Plan.Response;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IGetBranchesOfPlanRequest : IRequestBase<BranchListResponse>
    {
        IGetBranchesOfPlanRequest WithMaxResult(int maxResult);

        IGetBranchesOfPlanRequest StartAtIndex(int startIndex);

        IGetBranchesOfPlanRequest OnlyEnabledBranches();
    }
}