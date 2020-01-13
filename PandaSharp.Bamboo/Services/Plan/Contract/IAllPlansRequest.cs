using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Plan.Response;

namespace PandaSharp.Bamboo.Services.Plan.Contract
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
