using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Project.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Project.Aspect
{
    [TestFixture]
    public sealed class GetAllProjectsParameterAspectTest
    {
        [Test]
        public void ParameterAspectTest()
        {
            var requestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            requestMock
                .Setup(i => i.AddParameter("showEmpty", null))
                .Returns(requestMock.Object)
                .Verifiable();

            requestMock
                .Setup(i => i.AddParameter("expand", "projects.project.plans.plan"))
                .Returns(requestMock.Object)
                .Verifiable();

            var aspect = new GetAllProjectsParameterAspect
            {
                IncludeEmptyProjects = true
            };
            aspect.IncludePlanInformation();
            aspect.ApplyToRestRequest(requestMock.Object);

            requestMock.Verify();
            requestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var requestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            requestMock
                .Setup(i => i.AddParameter("expand", "projects.project"))
                .Returns(requestMock.Object)
                .Verifiable();

            var aspect = new GetAllProjectsParameterAspect();
            aspect.ApplyToRestRequest(requestMock.Object);

            requestMock.Verify();
            requestMock.VerifyNoOtherCalls();
        }
    }
}