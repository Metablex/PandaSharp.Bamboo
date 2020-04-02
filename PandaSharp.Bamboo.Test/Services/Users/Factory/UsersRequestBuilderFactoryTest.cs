using NUnit.Framework;
using PandaSharp.Bamboo.Services.Users.Contract;
using PandaSharp.Bamboo.Services.Users.Factory;
using PandaSharp.Bamboo.Test.Framework.Services.Factory;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Users.Factory
{
    [TestFixture]
    internal sealed class UsersRequestBuilderFactoryTest : RequestBuilderFactoryTestBase
    {
        [Test]
        public void GetCurrentUserTest()
        {
            SetupRequestRegistration<IGetCurrentUserRequest>(parameters => parameters.ShouldBeEmpty());

            var factory = new UsersRequestBuilderFactory(Container.Object);
            var request = factory.GetCurrentUser();

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }
    }
}