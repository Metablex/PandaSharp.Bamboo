using PandaSharp.Bamboo.Services.Users.Contract;
using PandaSharp.Bamboo.Services.Users.Factory;
using PandaSharp.Bamboo.Services.Users.Request;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Utils;

namespace PandaSharp.Bamboo.Services.Users
{
    internal sealed class UsersModule : IPandaContextModule
    {
        public void RegisterModule(IPandaContainer container, IPandaContainerContext context)
        {
            container
                .RequestRegistrationFor<IGetCurrentUserRequest>()
                .LatestRequest<GetCurrentUserRequest>()
                .Register(context);

            container.RegisterType<IUsersRequestBuilderFactory, UsersRequestBuilderFactory>();
        }
    }
}