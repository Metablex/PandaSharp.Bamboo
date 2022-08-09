using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Build.Aspect
{
    [TestFixture]
    public sealed class GetInformationOfBuildParameterAspectTest
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
        public void IncludeBuildInformationTest()
        {
            var aspect = new GetInformationOfBuildParameterAspect();
            aspect.IncludeBuildInformation(i => i.IncludingComments());
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("expand", "comments"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var aspect = new GetInformationOfBuildParameterAspect();
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.VerifyNoOtherCalls();
        }
    }
}