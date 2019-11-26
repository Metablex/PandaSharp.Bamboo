using PandaSharp.IoC.Contract;
using PandaSharp.Services.Users.Contract;

namespace PandaSharp.Services.Users.Factory
{
    internal sealed class UsersRequestBuilderFactory : IUsersRequestBuilderFactory
    {
        private readonly IPandaContainer _container;

        public UsersRequestBuilderFactory(IPandaContainer container)
        {
            _container = container;
        }

        public ICurrentUserRequest GetCurrentUser()
        {
            return _container.Resolve<ICurrentUserRequest>();
        }
    }
}