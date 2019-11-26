using PandaSharp.IoC.Contract;
using PandaSharp.Services.Users.Contract;
using PandaSharp.Services.Users.Factory;
using PandaSharp.Services.Users.Request;

namespace PandaSharp.Services.Users
{
    internal static class UsersModule
    {
        public static void RegisterUsersModule(this IPandaContainer container)
        {
            container.RegisterType<ICurrentUserRequest, CurrentUserRequest>();

            container.RegisterType<IUsersRequestBuilderFactory, UsersRequestBuilderFactory>();
        }
    }
}