using NUnit.Framework;
using PandaSharp.Bamboo.Services.Project.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Project.Aspect
{
    [TestFixture]
    public sealed class GetAllProjectsParameterAspectTest
    {
        [Test]
        public void SetIncludeEmptyProjectsTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllProjectsParameterAspect();
            aspect.SetIncludeEmptyProjects(true);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(2);
            request.Parameters.Exists(new GetOrPostParameter("showEmpty", "true")).ShouldBeTrue();
            request.Parameters.Exists(new GetOrPostParameter("expand", "projects.project")).ShouldBeTrue();
        }

        [Test]
        public void IncludePlanInformationTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllProjectsParameterAspect();
            aspect.IncludePlanInformation(i => i.IncludeActions());
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new GetOrPostParameter("expand", "projects.project.plans.plan.actions")).ShouldBeTrue();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var request = new RestRequest();

            var aspect = new GetAllProjectsParameterAspect();
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new GetOrPostParameter("expand", "projects.project")).ShouldBeTrue();
        }
    }
}
