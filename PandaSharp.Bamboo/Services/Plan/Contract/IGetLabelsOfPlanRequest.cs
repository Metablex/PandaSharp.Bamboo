using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface IGetLabelsOfPlanRequest : IRequestBase<LabelListResponse>
    {
    }
}