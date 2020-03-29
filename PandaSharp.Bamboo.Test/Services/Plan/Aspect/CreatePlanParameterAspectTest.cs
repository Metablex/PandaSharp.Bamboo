using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Plan.Aspect
{
    [TestFixture]
    public sealed class CreatePlanParameterAspectTest
    {
        [Test]
        public void ParameterAspectTest()
        {
            var requestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            requestMock
                .Setup(i => i.AddParameter("vcsBranch", "TestBranch", ParameterType.QueryStringWithoutEncode))
                .Returns(requestMock.Object);

            requestMock
                .Setup(i => i.AddParameter("enabled", true, ParameterType.QueryString))
                .Returns(requestMock.Object);

            requestMock
                .Setup(i => i.AddParameter("cleanupEnabled", false, ParameterType.QueryString))
                .Returns(requestMock.Object);

            var aspect = new CreatePlanParameterAspect
            {
                VcsBranch = "TestBranch",
                IsEnabled = true,
                IsCleanupEnabled = false
            };
            aspect.ApplyToRestRequest(requestMock.Object);

            requestMock.Verify();
            requestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var requestMock = new Mock<IRestRequest>(MockBehavior.Strict);

            var aspect = new CreatePlanParameterAspect();
            aspect.ApplyToRestRequest(requestMock.Object);

            requestMock.Verify();
            requestMock.VerifyNoOtherCalls();
        }
    }
}