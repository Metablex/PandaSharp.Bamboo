using NUnit.Framework;
using PandaSharp.Bamboo.Services.Users.Contract;
using PandaSharp.Bamboo.Services.Users.Factory;
using PandaSharp.Bamboo.Test.Framework.Services.Factory;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Users.Factory
{
    [TestFixture]
    internal sealed class UsersRequestBuilderFactoryTest
    {
        [Test]
        public void GetCurrentUserTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetCurrentUserRequest>(parameters => parameters.ShouldBeEmpty());

            var factory = new UsersRequestBuilderFactory(containerMock.Object);
            var request = factory.GetCurrentUser();

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }
    }
}