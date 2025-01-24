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
        public void SetPerformFuzzySearchTest()
        {
            var request = new RestRequest();

            var aspect = new PlanSearchParameterAspect();
            aspect.SetPerformFuzzySearch(true);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new GetOrPostParameter("fuzzy", "true")).ShouldBeTrue();
        }

        [Test]
        public void SetSearchTermTest()
        {
            var request = new RestRequest();

            var aspect = new PlanSearchParameterAspect();
            aspect.SetSearchTerm("SearchMe");
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(2);
            request.Parameters.Exists(new QueryParameter("searchTerm", "SearchMe")).ShouldBeTrue();
            request.Parameters.Exists(new GetOrPostParameter("fuzzy", "false")).ShouldBeTrue();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var request = new RestRequest();

            var aspect = new PlanSearchParameterAspect();
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new GetOrPostParameter("fuzzy", "false")).ShouldBeTrue();
        }
    }
}
