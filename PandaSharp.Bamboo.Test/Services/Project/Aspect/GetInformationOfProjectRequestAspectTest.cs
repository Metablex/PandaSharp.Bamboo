using NUnit.Framework;
using PandaSharp.Bamboo.Services.Project.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Project.Aspect
{
    [TestFixture]
    public sealed class GetInformationOfProjectRequestAspectTest
    {
        [Test]
        public void IncludePlanInformationTest()
        {
            var request = new RestRequest();

            var aspect = new GetInformationOfProjectRequestAspect();
            aspect.IncludePlanInformation(i => i.IncludeBranches());
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new GetOrPostParameter("expand", "plans.plan.branches")).ShouldBeTrue();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var request = new RestRequest();

            var aspect = new GetInformationOfProjectRequestAspect();
            aspect.ApplyToRestRequest(request);

            request.Parameters.ShouldBeEmpty();
        }
    }
}
