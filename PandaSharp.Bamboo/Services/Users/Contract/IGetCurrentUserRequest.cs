using PandaSharp.Bamboo.Services.Users.Response;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.Bamboo.Services.Users.Contract
{
    public interface IGetCurrentUserRequest : IRequestBase<CurrentUserResponse>
    {
    }
}