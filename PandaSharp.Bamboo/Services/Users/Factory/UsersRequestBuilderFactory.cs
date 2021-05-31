using PandaSharp.Bamboo.Services.Users.Contract;
using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.Bamboo.Services.Users.Factory
{
    internal sealed class UsersRequestBuilderFactory : IUsersRequestBuilderFactory
    {
        private readonly IPandaContainer _container;

        public UsersRequestBuilderFactory(IPandaContainer container)
        {
            _container = container;
        }

        public IGetCurrentUserRequest GetCurrentUser()
        {
            return _container.Resolve<IGetCurrentUserRequest>();
        }
    }
}