using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Plan.Response;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IVcsBranchesOfPlanRequest : IRequestBase<VcsBranchListResponse>
    {
        IVcsBranchesOfPlanRequest WithMaxResult(int maxResult);

        IVcsBranchesOfPlanRequest StartAtIndex(int startIndex);
    }
}