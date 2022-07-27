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
                .Setup(i => i.AddQueryParameter("vcsBranch", "TestBranch", false))
                .Returns(requestMock.Object);

            requestMock
                .Setup(i => i.AddQueryParameter("enabled", "True"))
                .Returns(requestMock.Object);

            requestMock
                .Setup(i => i.AddQueryParameter("cleanupEnabled", "False"))
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