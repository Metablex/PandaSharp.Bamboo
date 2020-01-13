using PandaSharp.Bamboo.IoC;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Services.Users.Contract;
using PandaSharp.Bamboo.Services.Users.Factory;
using PandaSharp.Bamboo.Services.Users.Request;
using PandaSharp.Bamboo.Utils;

namespace PandaSharp.Bamboo.Services.Users
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