using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Build.Aspect
{
    [TestFixture]
    public sealed class GetBuildsOfPlanParameterAspectTest
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
        public void IncludeBuildInformationTest()
        {
            var aspect = new GetBuildsOfPlanParameterAspect();
            aspect.IncludeBuildInformation(i => i.IncludingComments());
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddParameter("expand", "results.result.comments"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var aspect = new GetBuildsOfPlanParameterAspect();
            aspect.IncludeBuildInformation(i => i.IncludingComments());
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.VerifyNoOtherCalls();
        }
    }
}