using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Project.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Project.Aspect
{
    [TestFixture]
    public sealed class GetAllProjectsParameterAspectTest
    {
        private Mock<IRestRequest> _restRequestMock;

        [SetUp]
        public void SetUp()
        {
            _restRequestMock = new Mock<IRestRequest>();
            _restRequestMock
                .Setup(i => i.AddParameter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(_restRequestMock.Object);
        }
        
        [Test]
        public void SetIncludeEmptyProjectsTest()
        {
            var aspect = new GetAllProjectsParameterAspect();
            aspect.SetIncludeEmptyProjects(true);
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddParameter("showEmpty", true), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }
        
        [Test]
        public void IncludePlanInformationTest()
        {
            var aspect = new GetAllProjectsParameterAspect();
            aspect.IncludePlanInformation(i => i.IncludeActions());
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddParameter("expand", "projects.project.plans.plan.actions"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var aspect = new GetAllProjectsParameterAspect();
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.Verify(i => i.AddParameter("expand", "projects.project"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }
    }
}