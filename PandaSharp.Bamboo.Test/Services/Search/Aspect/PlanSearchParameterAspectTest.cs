using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Search.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Search.Aspect
{
    [TestFixture]
    public sealed class PlanSearchParameterAspectTest
    {
        [Test]
        public void ParameterAspectTest()
        {
            var aspect = new PlanSearchParameterAspect();
            aspect.PerformFuzzySearch.ShouldBeFalse();
            aspect.SearchTerm.ShouldBeNull();

            var restRequestMock = new Mock<IRestRequest>();

            aspect.ApplyToRestRequest(restRequestMock.Object);

            restRequestMock.Verify(r => r.AddParameter("fuzzy", false), Times.Once);
            restRequestMock.VerifyNoOtherCalls();
            restRequestMock.Invocations.Clear();

            aspect.SearchTerm = "SearchMe";
            aspect.PerformFuzzySearch = true;
            aspect.ApplyToRestRequest(restRequestMock.Object);

            restRequestMock.Verify(r => r.AddParameter("fuzzy", true), Times.Once);
            restRequestMock.Verify(r => r.AddParameter("searchTerm", "SearchMe"), Times.Once);
            restRequestMock.VerifyNoOtherCalls();
        }
    }
}