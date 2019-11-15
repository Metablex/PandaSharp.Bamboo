using PandaSharp.Services.Users.Contract;
using Unity;

namespace PandaSharp.Services.Users.Factory
{
    internal sealed class UsersRequestBuilderFactory : IUsersRequestBuilderFactory
    {
        private readonly IUnityContainer _container;

        public UsersRequestBuilderFactory(IUnityContainer container)
        {
            _container = container;
        }

        public ICurrentUserRequest GetCurrentUser()
        {
            return _container.Resolve<ICurrentUserRequest>();
        }
    }
}