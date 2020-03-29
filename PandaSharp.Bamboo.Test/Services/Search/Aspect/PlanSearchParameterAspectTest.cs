using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Search.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Search.Aspect
{
    [TestFixture]
    public sealed class PlanSearchParameterAspectTest
    {
        [Test]
        public void ParameterAspectTest()
        {
            var restRequestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            restRequestMock
                .Setup(i => i.AddParameter("fuzzy", true))
                .Returns(restRequestMock.Object)
                .Verifiable();

            restRequestMock
                .Setup(i => i.AddParameter("searchTerm", "SearchMe"))
                .Returns(restRequestMock.Object)
                .Verifiable();

            var aspect = new PlanSearchParameterAspect
            {
                SearchTerm = "SearchMe",
                PerformFuzzySearch = true
            };
            aspect.ApplyToRestRequest(restRequestMock.Object);

            restRequestMock.Verify();
            restRequestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var restRequestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            restRequestMock
                .Setup(i => i.AddParameter("fuzzy", false))
                .Returns(restRequestMock.Object)
                .Verifiable();

            var aspect = new PlanSearchParameterAspect();
            aspect.ApplyToRestRequest(restRequestMock.Object);

            restRequestMock.Verify();
            restRequestMock.VerifyNoOtherCalls();
        }
    }
}