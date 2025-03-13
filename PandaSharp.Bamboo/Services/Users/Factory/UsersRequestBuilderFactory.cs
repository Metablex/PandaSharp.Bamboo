using PandaSharp.Bamboo.Services.Users.Contract;
using PandaSharp.Bamboo.Services.Users.Request;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Rest.Common;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;

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
            var restFactory = CreateRestFactory();

            return new GetCurrentUserRequest(
                restFactory,
                _container.Resolve<IRequestParameterAspectFactory>(),
                _container.Resolve<IRestResponseConverterFactory>());
        }

        private IRestFactory CreateRestFactory()
        {
            return new RestFactory(_container.Resolve<IRestOptions>(), JsonRestSerializer.Default);
        }
    }
}
