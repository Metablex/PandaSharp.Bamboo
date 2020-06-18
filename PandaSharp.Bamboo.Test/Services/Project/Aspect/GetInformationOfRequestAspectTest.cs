using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Project.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Project.Aspect
{
    [TestFixture]
    public sealed class GetInformationOfRequestAspectTest
    {
        [Test]
        public void ParameterAspectTest()
        {
            var requestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            requestMock
                .Setup(i => i.AddParameter("expand", "plans.plan"))
                .Returns(requestMock.Object)
                .Verifiable();

            var aspect = new GetInformationOfRequestAspect();
            aspect.IncludePlanInformation();
            aspect.ApplyToRestRequest(requestMock.Object);

            requestMock.Verify();
            requestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var requestMock = new Mock<IRestRequest>(MockBehavior.Strict);

            var aspect = new GetInformationOfRequestAspect();
            aspect.ApplyToRestRequest(requestMock.Object);

            requestMock.Verify();
            requestMock.VerifyNoOtherCalls();
        }
    }
}