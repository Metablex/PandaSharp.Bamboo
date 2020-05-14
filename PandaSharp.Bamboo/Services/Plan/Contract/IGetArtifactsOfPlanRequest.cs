using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Plan.Response;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IGetArtifactsOfPlanRequest : IRequestBase<ArtifactListResponse>
    {
        IGetArtifactsOfPlanRequest WithMaxResult(int maxResult);

        IGetArtifactsOfPlanRequest StartAtIndex(int startIndex);
    }
}