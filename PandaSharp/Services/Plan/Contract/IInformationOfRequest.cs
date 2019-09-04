using PandaSharp.Services.Common.Contract;
using PandaSharp.Services.Plan.Response;

namespace PandaSharp.Services.Plan.Contract
{
    public interface IInformationOfRequest : IRequestBase<PlanResponse>
    {
        IInformationOfRequest IncludeActions();

        IInformationOfRequest IncludeStages();

        IInformationOfRequest IncludeBranches(int maxResults = 25);

        IInformationOfRequest IncludeVariableContext();
    }
}