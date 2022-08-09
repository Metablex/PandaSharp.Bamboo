using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Build.Aspect
{
    [TestFixture]
    public sealed class LabelFilterParameterAspectTest
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
            var aspect = new LabelFilterParameterAspect();
            aspect.SetLabelsFilter(new[] { "Label1", "Label2" });
            aspect.ApplyToRestRequest(_restRequestMock.Object);
            
            _restRequestMock.Verify(i => i.AddQueryParameter("label", "Label1,Label2"), Times.Once);
            _restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var aspect = new LabelFilterParameterAspect();
            aspect.ApplyToRestRequest(_restRequestMock.Object);

            _restRequestMock.VerifyNoOtherCalls();
        }
    }
}