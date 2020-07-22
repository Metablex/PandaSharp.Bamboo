using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Build.Aspect
{
    [TestFixture]
    public sealed class GetInformationOfBuildParameterAspectTest
    {
        [Test]
        public void ParameterAspectTest()
        {
            var requestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            requestMock
                .Setup(i => i.AddParameter("expand", "comments", ParameterType.QueryString))
                .Returns(requestMock.Object)
                .Verifiable();

            var aspect = new GetInformationOfBuildParameterAspect();
            aspect.IncludeBuildInformation(i => i.IncludingComments());
            aspect.ApplyToRestRequest(requestMock.Object);

            requestMock.Verify();
            requestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var requestMock = new Mock<IRestRequest>(MockBehavior.Strict);

            var aspect = new GetInformationOfBuildParameterAspect();
            aspect.ApplyToRestRequest(requestMock.Object);

            requestMock.Verify();
            requestMock.VerifyNoOtherCalls();
        }
    }
}