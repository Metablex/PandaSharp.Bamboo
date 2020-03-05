using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Services.Users.Contract;
using PandaSharp.Bamboo.Services.Users.Factory;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Users.Factory
{
    [TestFixture]
    public sealed class UsersRequestBuilderFactoryTest
    {
        [Test]
        public void GetCurrentUserTest()
        {
            var containerMock = new Mock<IPandaContainer>(MockBehavior.Strict);
            containerMock
                .Setup(c => c.Resolve<ICurrentUserRequest>())
                .Returns(() => new Mock<ICurrentUserRequest>().Object);

            var factory = new UsersRequestBuilderFactory(containerMock.Object);
            var request = factory.GetCurrentUser();

            request.ShouldNotBeNull();
        }
    }
}