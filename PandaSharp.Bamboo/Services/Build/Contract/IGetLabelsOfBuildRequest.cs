using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Common.Contract;

namespace PandaSharp.Bamboo.Services.Build.Contract
{
    public interface IGetLabelsOfBuildRequest : IRequestBase<LabelListResponse>
    {
    }
}