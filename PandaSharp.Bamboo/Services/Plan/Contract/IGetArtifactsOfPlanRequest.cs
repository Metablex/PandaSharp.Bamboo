using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IGetArtifactsOfPlanRequest : IRequestBase<ArtifactListResponse>
    {
        IGetArtifactsOfPlanRequest WithMaxResult(int maxResult);

        IGetArtifactsOfPlanRequest StartAtIndex(int startIndex);
    }
}