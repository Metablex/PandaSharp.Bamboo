using System;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Common.Aspect
{
    [TestFixture]
    public sealed class ExpandStateParameterAspectTest
    {
        [Test]
        public void ParameterAspectTest()
        {
            var aspect = new ExpandStateParameterAspect<TestEnum>();

            var restRequestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            restRequestMock
                .Setup(r => r.AddParameter(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(restRequestMock.Object)
                .Verifiable();

            aspect.ApplyToRestRequest(restRequestMock.Object);
            restRequestMock.VerifyNoOtherCalls();

            aspect.AddExpandState(TestEnum.A);
            aspect.AddExpandState(TestEnum.B);
            aspect.ApplyToRestRequest(restRequestMock.Object);

            restRequestMock.Verify(r => r.AddParameter("expand", "A,B"), Times.Once);
            restRequestMock.VerifyNoOtherCalls();
        }

        [Flags]
        private enum TestEnum
        {
            [StringRepresentation("A")]
            A = 1 << 0,

            [StringRepresentation("B")]
            B = 1 << 1
        }
    }
}