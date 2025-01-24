using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Aspect
{
    [TestFixture]
    public sealed class GetBranchesOfPlanParameterAspectTest
    {
        [Test]
        public void SetOnlyEnabledBranchesFilterTest()
        {
            var request = new RestRequest();

            var aspect = new GetBranchesOfPlanParameterAspect();
            aspect.SetOnlyEnabledBranchesFilter(true);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new GetOrPostParameter("enabledOnly", "true")).ShouldBeTrue();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var request = new RestRequest();

            var aspect = new GetBranchesOfPlanParameterAspect();
            aspect.ApplyToRestRequest(request);

            request.Parameters.ShouldBeEmpty();
        }
    }
}
