using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Plan.Response;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IArtifactsOfPlanRequest : IRequestBase<ArtifactListResponse>
    {
        IArtifactsOfPlanRequest WithMaxResult(int maxResult);

        IArtifactsOfPlanRequest StartAtIndex(int startIndex);
    }
}