using PandaSharp.Services.Common.Contract;
using PandaSharp.Services.Plan.Response;

namespace PandaSharp.Services.Plan.Contract
{
    public interface IAllPlansRequest : IRequestBase<PlansResponse>
    {
        IAllPlansRequest WithMaxResult(int maxResult);

        IAllPlansRequest StartAtIndex(int startIndex);

        IAllPlansRequest IncludeDetails();

        IAllPlansRequest IncludeActionsInformation();

        IAllPlansRequest IncludeStagesInformation();

        IAllPlansRequest IncludeBranchesInformation();
    }
}
