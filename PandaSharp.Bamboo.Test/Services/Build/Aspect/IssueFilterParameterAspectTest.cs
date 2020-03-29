using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Build.Aspect
{
    [TestFixture]
    public sealed class IssueFilterParameterAspectTest
    {
        [Test]
        public void ParameterAspectTest()
        {
            var requestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            requestMock
                .Setup(i => i.AddParameter("issueKey", "Issue1,Issue2"))
                .Returns(requestMock.Object)
                .Verifiable();

            var aspect = new IssueFilterParameterAspect
            {
                Issues = new List<string> { "Issue1", "Issue2" }
            };
            aspect.ApplyToRestRequest(requestMock.Object);

            requestMock.Verify();
            requestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var requestMock = new Mock<IRestRequest>(MockBehavior.Strict);

            var aspect = new IssueFilterParameterAspect();
            aspect.ApplyToRestRequest(requestMock.Object);

            requestMock.VerifyNoOtherCalls();
        }
    }
}