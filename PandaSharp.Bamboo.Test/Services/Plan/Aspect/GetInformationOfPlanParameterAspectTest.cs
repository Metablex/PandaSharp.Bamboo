using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Plan.Aspect
{
    [TestFixture]
    public sealed class GetInformationOfPlanParameterAspectTest
    {
        private Mock<IRestRequest> _restRequestMock;

        [SetUp]
        public void SetUp()
        {
            _restRequestMock = new Mock<IRestRequest>();
            _restRequestMock
                .Setup(i => i.AddQueryParameter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(_restRequestMock.Object);
        }
        
        [Test]
        public void IncludePlanInformationTest()
        {
            var aspect = new GetInformationOfPlanParameterAspect();
            aspect.IncludePlanInformation(i => i.IncludeStages());
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("expand", "stages"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var aspect = new GetInformationOfPlanParameterAspect();
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.VerifyNoOtherCalls();
        }
    }
}