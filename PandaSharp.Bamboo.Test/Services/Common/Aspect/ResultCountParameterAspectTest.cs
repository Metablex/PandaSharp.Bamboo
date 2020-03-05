using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Common.Aspect
{
    [TestFixture]
    public sealed class ResultCountParameterAspectTest
    {
        [Test]
        public void ParameterAspectTest()
        {
            var aspect = new ResultCountParameterAspect();

            var restRequestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            restRequestMock
                .Setup(r => r.AddParameter(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<ParameterType>()))
                .Returns(restRequestMock.Object)
                .Verifiable();

            aspect.MaxResults.ShouldBeNull();
            aspect.StartIndex.ShouldBeNull();
            aspect.ApplyToRestRequest(restRequestMock.Object);
            restRequestMock.VerifyNoOtherCalls();

            aspect.MaxResults = 10;
            aspect.StartIndex = 5;
            aspect.ApplyToRestRequest(restRequestMock.Object);

            restRequestMock.Verify(r => r.AddParameter("start-index", 5, ParameterType.QueryString), Times.Once);
            restRequestMock.Verify(r => r.AddParameter("max-results", 10, ParameterType.QueryString), Times.Once);
            restRequestMock.VerifyNoOtherCalls();
        }
    }
}