using PandaSharp.Services.Users.Contract;
using PandaSharp.Services.Users.Factory;
using PandaSharp.Services.Users.Request;
using Unity;

namespace PandaSharp.Services.Users
{
    internal static class UsersModule
    {
        public static void RegisterUsersModule(this IUnityContainer container)
        {
            container.RegisterType<ICurrentUserRequest, CurrentUserRequest>();

            container.RegisterType<IUsersRequestBuilderFactory, UsersRequestBuilderFactory>();
        }
    }
}