namespace PandaSharp.Bamboo.Services.Users.Contract
{
    public interface IUsersRequestBuilderFactory
    {
        ICurrentUserRequest GetCurrentUser();
    }
}