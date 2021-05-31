using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IGetBranchesOfPlanRequest : IRequestBase<BranchListResponse>
    {
        IGetBranchesOfPlanRequest WithMaxResult(int maxResult);

        IGetBranchesOfPlanRequest StartAtIndex(int startIndex);

        IGetBranchesOfPlanRequest OnlyEnabledBranches();
    }
}