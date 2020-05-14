using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Common.Response;

namespace PandaSharp.Bamboo.Services.Build.Contract
{
    public interface IGetLabelsOfBuildRequest : IRequestBase<LabelListResponse>
    {
    }
}