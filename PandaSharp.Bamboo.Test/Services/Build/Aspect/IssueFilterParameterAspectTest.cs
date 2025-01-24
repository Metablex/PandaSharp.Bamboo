using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Aspect
{
    [TestFixture]
    public sealed class IssueFilterParameterAspectTest
    {
        [Test]
        public void SetIssuesFilterTest()
        {
            var request = new RestRequest();

            var aspect = new IssueFilterParameterAspect();
            aspect.SetIssuesFilter(new[] { "Issue1", "Issue2" });
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("issueKey", "Issue1,Issue2")).ShouldBeTrue();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var request = new RestRequest();

            var aspect = new IssueFilterParameterAspect();
            aspect.ApplyToRestRequest(request);

            request.Parameters.ShouldBeEmpty();
        }
    }
}
