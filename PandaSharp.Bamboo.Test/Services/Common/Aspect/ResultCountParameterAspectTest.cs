using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Common.Aspect
{
    [TestFixture]
    public sealed class ResultCountParameterAspectTest
    {
        [Test]
        public void SetMaxResultsTest()
        {
            var request = new RestRequest();

            var aspect = new ResultCountParameterAspect();
            aspect.SetMaxResults(10);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("max-results", "10")).ShouldBeTrue();
        }

        [Test]
        public void SetStartIndexTest()
        {
            var request = new RestRequest();

            var aspect = new ResultCountParameterAspect();
            aspect.SetStartIndex(5);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("start-index", "5")).ShouldBeTrue();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var request = new RestRequest();

            var aspect = new ResultCountParameterAspect();
            aspect.ApplyToRestRequest(request);

            request.Parameters.ShouldBeEmpty();
        }
    }
}
