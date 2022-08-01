using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Search.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Search.Aspect
{
    [TestFixture]
    public sealed class PlanSearchParameterAspectTest
    {
        private Mock<IRestRequest> _restRequestMock;

        [SetUp]
        public void SetUp()
        {
            _restRequestMock = new Mock<IRestRequest>();
            _restRequestMock
                .Setup(i => i.AddParameter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(_restRequestMock.Object);
            
            _restRequestMock
                .Setup(i => i.AddQueryParameter(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(_restRequestMock.Object);
        }
        
        [Test]
        public void SetPerformFuzzySearchTest()
        {
            var aspect = new PlanSearchParameterAspect();
            aspect.SetPerformFuzzySearch(true);
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddParameter("fuzzy", true), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }
        
        [Test]
        public void SetSearchTermTest()
        {
            var aspect = new PlanSearchParameterAspect();
            aspect.SetSearchTerm("SearchMe");
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("searchTerm", "SearchMe"), Times.Once);
            _restRequestMock.Verify(i => i.AddParameter("fuzzy", false), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var aspect = new PlanSearchParameterAspect();
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.Verify(i => i.AddParameter("fuzzy", false), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }
    }
}