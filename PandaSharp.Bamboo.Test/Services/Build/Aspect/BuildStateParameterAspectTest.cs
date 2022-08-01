using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Types;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Build.Aspect
{
    [TestFixture]
    public sealed class BuildStateParameterAspectTest
    {
        private Mock<IRestRequest> _restRequestMock;

        [SetUp]
        public void SetUp()
        {
            _restRequestMock = new Mock<IRestRequest>();
            _restRequestMock
                .Setup(i => i.AddParameter(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(_restRequestMock.Object);
        }
        
        [Test]
        public void SetBuildStateFilterTest()
        {
            var aspect = new BuildStateParameterAspect();
            aspect.SetBuildStateFilter(BuildState.Failed);
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddParameter("buildstate", "failed"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var aspect = new BuildStateParameterAspect();
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.Verify(i => i.AddParameter("includeAllStates", true), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }
    }
}