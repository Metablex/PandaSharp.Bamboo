using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Common.Aspect
{
    [TestFixture]
    public sealed class ResultCountParameterAspectTest
    {
        [Test]
        public void ParameterAspectTest()
        {
            var restRequestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            restRequestMock
                .Setup(r => r.AddQueryParameter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(restRequestMock.Object)
                .Verifiable();

            var aspect = new ResultCountParameterAspect
            {
                MaxResults = 10,
                StartIndex = 5
            };
            aspect.ApplyToRestRequest(restRequestMock.Object);

            restRequestMock.Verify();
            restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var restRequestMock = new Mock<IRestRequest>(MockBehavior.Strict);

            var aspect = new ResultCountParameterAspect();
            aspect.ApplyToRestRequest(restRequestMock.Object);

            restRequestMock.Verify();
            restRequestMock.VerifyNoOtherCalls();
        }
    }
}