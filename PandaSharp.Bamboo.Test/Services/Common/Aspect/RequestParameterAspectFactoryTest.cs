using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Common.Aspect
{
    [TestFixture]
    public sealed class RequestParameterAspectFactoryTest
    {
        [Test]
        public void GetParameterAspectsTest()
        {
            var containerMock = new Mock<IPandaContainer>(MockBehavior.Strict);
            containerMock
                .Setup(c => c.Resolve(typeof(IAspectA)))
                .Returns(new Mock<IAspectA>().Object);

            containerMock
                .Setup(c => c.Resolve(typeof(IAspectB)))
                .Returns(new Mock<IAspectB>().Object);

            var factory = new RequestParameterAspectFactory(containerMock.Object);
            var aspects = factory.GetParameterAspects(typeof(TestAspectClass));

            aspects.Count.ShouldBe(2);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        internal interface IAspectA : IRequestParameterAspect
        {
        }

        // ReSharper disable once MemberCanBePrivate.Global
        internal interface IAspectB : IRequestParameterAspect
        {
        }

        [SupportsParameterAspect(typeof(IAspectA))]
        [SupportsParameterAspect(typeof(IAspectB))]
        private class TestAspectClass
        {
        }
    }
}