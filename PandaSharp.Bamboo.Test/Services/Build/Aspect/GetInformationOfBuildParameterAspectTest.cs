using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Aspect
{
    [TestFixture]
    public sealed class GetInformationOfBuildParameterAspectTest
    {
        [Test]
        public void IncludeBuildInformationTest()
        {
            var request = new RestRequest();

            var aspect = new GetInformationOfBuildParameterAspect();
            aspect.IncludeBuildInformation(i => i.IncludingComments());
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("expand", "comments")).ShouldBeTrue();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var request = new RestRequest();

            var aspect = new GetInformationOfBuildParameterAspect();
            aspect.ApplyToRestRequest(request);

            request.Parameters.ShouldBeEmpty();
        }
    }
}
