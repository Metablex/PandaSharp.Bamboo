using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Plan.Aspect
{
    [TestFixture]
    public sealed class CreatePlanParameterAspectTest
    {
        private Mock<IRestRequest> _restRequestMock;

        [SetUp]
        public void SetUp()
        {
            _restRequestMock = new Mock<IRestRequest>();
            _restRequestMock
                .Setup(i => i.AddQueryParameter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(_restRequestMock.Object);
            
            _restRequestMock
                .Setup(i => i.AddQueryParameter(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(_restRequestMock.Object);
        }
        
        [Test]
        public void SetVcsBranchFilterTest()
        {
            var aspect = new CreatePlanParameterAspect();
            aspect.SetVcsBranchFilter("branch");
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("vcsBranch", "branch", false), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }
        
        [Test]
        public void SetIsEnabledFilterTest()
        {
            var aspect = new CreatePlanParameterAspect();
            aspect.SetIsEnabledFilter(true);
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("enabled", "True"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }
        
        [Test]
        public void SetIsCleanupEnabledFilterTest()
        {
            var aspect = new CreatePlanParameterAspect();
            aspect.SetIsCleanupEnabledFilter(true);
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("cleanupEnabled", "True"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var aspect = new CreatePlanParameterAspect();
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.VerifyNoOtherCalls();
        }
    }
}