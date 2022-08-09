using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Plan.Aspect
{
    [TestFixture]
    public sealed class GetBranchesOfPlanParameterAspectTest
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
        public void SetOnlyEnabledBranchesFilterTest()
        {
            var aspect = new GetBranchesOfPlanParameterAspect();
            aspect.SetOnlyEnabledBranchesFilter(true);
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddParameter("enabledOnly", true), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var aspect = new GetBranchesOfPlanParameterAspect();
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.VerifyNoOtherCalls();
        }
    }
}