using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.Bamboo.Services.Build.Contract
{
    public interface IGetLabelsOfBuildRequest : IRequestBase<LabelListResponse>
    {
    }
}