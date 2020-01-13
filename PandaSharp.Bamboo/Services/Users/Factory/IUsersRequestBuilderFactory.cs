using PandaSharp.Bamboo.Services.Users.Contract;

namespace PandaSharp.Bamboo.Services.Users.Factory
{
    public interface IUsersRequestBuilderFactory
    {
        ICurrentUserRequest GetCurrentUser();
    }
}