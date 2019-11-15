using PandaSharp.Services.Common.Contract;
using PandaSharp.Services.Users.Response;

namespace PandaSharp.Services.Users.Contract
{
    public interface ICurrentUserRequest : IRequestBase<CurrentUserResponse>
    {
    }
}