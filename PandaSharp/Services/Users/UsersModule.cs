using PandaSharp.IoC;
using PandaSharp.IoC.Contract;
using PandaSharp.Services.Users.Contract;
using PandaSharp.Services.Users.Factory;
using PandaSharp.Services.Users.Request;
using PandaSharp.Utils;

namespace PandaSharp.Services.Users
{
    internal sealed class UsersModule : PandaContextModuleBase
    {
        public override void RegisterModule(IPandaContainer container, PandaContainerContext context)
        {
            container
                .RequestRegistrationFor<ICurrentUserRequest>()
                .LatestRequest<CurrentUserRequest>()
                .Register(context);

            container.RegisterType<IUsersRequestBuilderFactory, UsersRequestBuilderFactory>();
        }
    }
}