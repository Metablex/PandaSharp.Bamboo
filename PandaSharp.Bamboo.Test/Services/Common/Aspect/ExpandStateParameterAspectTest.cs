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
            var restRequestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            restRequestMock
                .Setup(r => r.AddParameter("expand", "A,B"))
                .Returns(restRequestMock.Object)
                .Verifiable();

            var aspect = new ExpandStateParameterAspect<TestEnum>();
            aspect.AddExpandState(TestEnum.A);
            aspect.AddExpandState(TestEnum.B);
            aspect.ApplyToRestRequest(restRequestMock.Object);

            restRequestMock.Verify();
            restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var restRequestMock = new Mock<IRestRequest>(MockBehavior.Strict);

            var aspect = new ExpandStateParameterAspect<TestEnum>();
            aspect.ApplyToRestRequest(restRequestMock.Object);

            restRequestMock.Verify();
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