using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Users.Response;

namespace PandaSharp.Bamboo.Services.Users.Contract
{
    public interface IGetCurrentUserRequest : IRequestBase<CurrentUserResponse>
    {
    }
}