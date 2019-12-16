using PandaSharp.Services.Common.Contract;
using PandaSharp.Services.Plan.Response;

namespace PandaSharp.Services.Plan.Contract
{
    public interface IInformationOfPlanRequest : IRequestBase<PlanResponse>
    {
        IInformationOfPlanRequest IncludeActions();

        IInformationOfPlanRequest IncludeStages();

        IInformationOfPlanRequest IncludeBranches(int maxResults = 25);

        IInformationOfPlanRequest IncludeVariableContext();
    }
}