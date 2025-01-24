using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Aspect
{
    [TestFixture]
    public sealed class GetAllPlansParameterAspectTest
    {
        [Test]
        public void IncludePlanInformationTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllPlansParameterAspect();
            aspect.IncludePlanInformation(i => i.IncludeStages());
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new GetOrPostParameter("expand", "plans.plan.stages")).ShouldBeTrue();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllPlansParameterAspect();
            aspect.ApplyToRestRequest(request);

            request.Parameters.ShouldBeEmpty();
        }
    }
}
