using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Aspect
{
    [TestFixture]
    public sealed class LabelFilterParameterAspectTest
    {
        [Test]
        public void SetIssuesFilterTest()
        {
            var request = new RestRequest();

            var aspect = new LabelFilterParameterAspect();
            aspect.SetLabelsFilter(new[] { "Label1", "Label2" });
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            request.Parameters.Exists(new QueryParameter("label", "Label1,Label2")).ShouldBeTrue();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var request = new RestRequest();

            var aspect = new LabelFilterParameterAspect();
            aspect.ApplyToRestRequest(request);

            request.Parameters.ShouldBeEmpty();
        }
    }
}
