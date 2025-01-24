using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Types;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Aspect
{
    [TestFixture]
    public sealed class BuildStateParameterAspectTest
    {
        [Test]
        public void SetBuildStateFilterTest()
        {
            var request = new RestRequest();

            var aspect = new BuildStateParameterAspect();
            aspect.SetBuildStateFilter(BuildState.Failed);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new GetOrPostParameter("buildstate", "failed")).ShouldBeTrue();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var request = new RestRequest();

            var aspect = new BuildStateParameterAspect();
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new GetOrPostParameter("includeAllStates", "True")).ShouldBeTrue();
        }
    }
}
