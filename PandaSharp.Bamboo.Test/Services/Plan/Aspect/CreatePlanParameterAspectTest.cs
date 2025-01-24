using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Aspect
{
    [TestFixture]
    public sealed class CreatePlanParameterAspectTest
    {
        [Test]
        public void SetVcsBranchFilterTest()
        {
            var request = new RestRequest();

            var aspect = new CreatePlanParameterAspect();
            aspect.SetVcsBranchFilter("branch");
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("vcsBranch", "branch")).ShouldBeTrue();
        }

        [Test]
        public void SetIsEnabledFilterTest()
        {
            var request = new RestRequest();

            var aspect = new CreatePlanParameterAspect();
            aspect.SetIsEnabledFilter(true);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("enabled", "True")).ShouldBeTrue();
        }

        [Test]
        public void SetIsCleanupEnabledFilterTest()
        {
            var request = new RestRequest();

            var aspect = new CreatePlanParameterAspect();
            aspect.SetIsCleanupEnabledFilter(true);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("cleanupEnabled", "True")).ShouldBeTrue();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var request = new RestRequest();

            var aspect = new CreatePlanParameterAspect();
            aspect.ApplyToRestRequest(request);

            request.Parameters.ShouldBeEmpty();
        }
    }
}
