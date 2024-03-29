using System;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IGetInformationOfPlanRequest : IRequestBase<PlanResponse>
    {
        IGetInformationOfPlanRequest WithMaxBranchResults(int maxResults = 25);

        IGetInformationOfPlanRequest IncludePlanInformation(params Action<IPlanInformationExpansion>[] expansions);
    }
}