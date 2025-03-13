using PandaSharp.Bamboo.Services.Users.Factory;
using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.Bamboo.Services.Users
{
    internal sealed class UsersModule : IPandaContainerModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IUsersRequestBuilderFactory, UsersRequestBuilderFactory>();
        }
    }
}
