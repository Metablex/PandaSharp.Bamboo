namespace PandaSharp.Services.Users.Contract
{
    public interface IUsersRequestBuilderFactory
    {
        ICurrentUserRequest GetCurrentUser();
    }
}