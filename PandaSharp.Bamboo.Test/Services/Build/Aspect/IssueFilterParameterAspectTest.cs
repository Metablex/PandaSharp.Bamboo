using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Build.Aspect
{
    [TestFixture]
    public sealed class IssueFilterParameterAspectTest
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
        public void SetIssuesFilterTest()
        {
            var aspect = new IssueFilterParameterAspect();
            aspect.SetIssuesFilter(new[] { "Issue1", "Issue2" });
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("issueKey", "Issue1,Issue2"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var aspect = new IssueFilterParameterAspect();
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.VerifyNoOtherCalls();
        }
    }
}