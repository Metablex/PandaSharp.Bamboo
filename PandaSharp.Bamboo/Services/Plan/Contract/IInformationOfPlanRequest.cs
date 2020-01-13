using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Plan.Response;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IInformationOfPlanRequest : IRequestBase<PlanResponse>
    {
        IInformationOfPlanRequest IncludeActions();

        IInformationOfPlanRequest IncludeStages();

        IInformationOfPlanRequest IncludeBranches(int maxResults = 25);

        IInformationOfPlanRequest IncludeVariableContext();
    }
}