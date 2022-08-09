using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Common.Aspect
{
    [TestFixture]
    public sealed class ResultCountParameterAspectTest
    {
        private Mock<IRestRequest> _restRequestMock;

        [SetUp]
        public void SetUp()
        {
            _restRequestMock = new Mock<IRestRequest>();
            _restRequestMock
                .Setup(i => i.AddQueryParameter(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(_restRequestMock.Object);
        }
        
        [Test]
        public void SetMaxResultsTest()
        {
            var aspect = new ResultCountParameterAspect();
            aspect.SetMaxResults(10);
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("max-results", "10"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }
        
        [Test]
        public void SetStartIndexTest()
        {
            var aspect = new ResultCountParameterAspect();
            aspect.SetStartIndex(5);
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("start-index", "5"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }
        
        [Test]
        public void DefaultParameterAspectTest()
        {
            var aspect = new ResultCountParameterAspect();
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.VerifyNoOtherCalls();
        }
    }
}