using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Services.Search.Contract;
using PandaSharp.Bamboo.Services.Search.Factory;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Search.Factory
{
    [TestFixture]
    public sealed class SearchRequestBuilderFactoryTest
    {
        [Test]
        public void ForPlansTest()
        {
            var containerMock = new Mock<IPandaContainer>();
            containerMock
                .Setup(c => c.Resolve<IPlanSearchRequest>())
                .Returns(() => new Mock<IPlanSearchRequest>().Object);

            var factory = new SearchRequestBuilderFactory(containerMock.Object);
            var request = factory.ForPlans();

            request.ShouldNotBeNull();
        }
    }
}