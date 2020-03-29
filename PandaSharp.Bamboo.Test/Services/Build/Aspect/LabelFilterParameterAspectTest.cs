using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Build.Aspect
{
    [TestFixture]
    public sealed class LabelFilterParameterAspectTest
    {
        [Test]
        public void ParameterAspectTest()
        {
            var requestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            requestMock
                .Setup(i => i.AddParameter("label", "Label1,Label2"))
                .Returns(requestMock.Object)
                .Verifiable();

            var aspect = new LabelFilterParameterAspect
            {
                Labels = new List<string> { "Label1", "Label2" }
            };
            aspect.ApplyToRestRequest(requestMock.Object);

            requestMock.Verify();
            requestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var requestMock = new Mock<IRestRequest>(MockBehavior.Strict);

            var aspect = new LabelFilterParameterAspect();
            aspect.ApplyToRestRequest(requestMock.Object);

            requestMock.VerifyNoOtherCalls();
        }
    }
}