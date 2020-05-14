using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Plan.Response;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IGetInformationOfPlanRequest : IRequestBase<PlanResponse>
    {
        IGetInformationOfPlanRequest IncludeActions();

        IGetInformationOfPlanRequest IncludeStages();

        IGetInformationOfPlanRequest IncludeBranches(int maxResults = 25);

        IGetInformationOfPlanRequest IncludeVariableContext();
    }
}