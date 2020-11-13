using System;
using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Bamboo.Services.Plan.Response;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IGetAllPlansRequest : IRequestBase<PlanListResponse>
    {
        IGetAllPlansRequest WithMaxResult(int maxResult);

        IGetAllPlansRequest StartAtIndex(int startIndex);

        IGetAllPlansRequest IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions);
    }
}
