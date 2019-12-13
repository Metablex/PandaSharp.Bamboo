using PandaSharp.IoC;
using PandaSharp.IoC.Contract;
using PandaSharp.Services.Users.Contract;
using PandaSharp.Services.Users.Factory;
using PandaSharp.Services.Users.Request;

namespace PandaSharp.Services.Users
{
    internal sealed class UsersModule : PandaModuleBase
    {
        public override void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<ICurrentUserRequest, CurrentUserRequest>();

            container.RegisterType<IUsersRequestBuilderFactory, UsersRequestBuilderFactory>();
        }
    }
}