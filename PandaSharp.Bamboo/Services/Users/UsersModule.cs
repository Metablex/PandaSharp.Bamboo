using PandaSharp.Bamboo.Services.Users.Contract;
using PandaSharp.Bamboo.Services.Users.Factory;
using PandaSharp.Bamboo.Services.Users.Request;
using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.Bamboo.Services.Users
{
    internal sealed class UsersModule : IPandaContainerModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IGetCurrentUserRequest, GetCurrentUserRequest>();
            container.RegisterType<IUsersRequestBuilderFactory, UsersRequestBuilderFactory>();
        }
    }
}