using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IGetVcsBranchesOfPlanRequest : IRequestBase<VcsBranchListResponse>
    {
        IGetVcsBranchesOfPlanRequest WithMaxResult(int maxResult);

        IGetVcsBranchesOfPlanRequest StartAtIndex(int startIndex);
    }
}