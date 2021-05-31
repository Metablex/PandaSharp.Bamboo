using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.Bamboo.Services.Build.Contract
{
    public interface IGetCommentsOfBuildRequest : IRequestBase<CommentListResponse>
    {
    }
}