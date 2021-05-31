using System;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IGetAllPlansRequest : IRequestBase<PlanListResponse>
    {
        IGetAllPlansRequest WithMaxResult(int maxResult);

        IGetAllPlansRequest StartAtIndex(int startIndex);

        IGetAllPlansRequest IncludePlanInformation(params Action<IPlanListInformationExpansion>[] expansions);
    }
}
