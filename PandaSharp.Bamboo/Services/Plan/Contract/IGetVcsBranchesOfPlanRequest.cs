using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Plan.Response;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IGetVcsBranchesOfPlanRequest : IRequestBase<VcsBranchListResponse>
    {
        IGetVcsBranchesOfPlanRequest WithMaxResult(int maxResult);

        IGetVcsBranchesOfPlanRequest StartAtIndex(int startIndex);
    }
}