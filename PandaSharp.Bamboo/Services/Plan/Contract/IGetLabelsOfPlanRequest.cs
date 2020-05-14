using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Common.Response;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IGetLabelsOfPlanRequest : IRequestBase<LabelListResponse>
    {
    }
}