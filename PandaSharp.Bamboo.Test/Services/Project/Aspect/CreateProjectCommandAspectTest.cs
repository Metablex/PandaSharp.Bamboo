using System.Linq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Project.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Project.Aspect
{
    [TestFixture]
    public sealed class CreateProjectCommandAspectTest
    {
        [Test]
        public void ParameterAspectTest()
        {
            var request = new RestRequest();

            var aspect = new CreateProjectCommandAspect();
            aspect.SetProjectKey("Project");
            aspect.SetProjectName("Name");
            aspect.SetDescription("Description");
            aspect.EnablePublicAccess(true);
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            var jsonParameter = request.Parameters.TryFind(string.Empty).ShouldBeOfType<JsonParameter>();
            var json = jsonParameter.Value.ShouldBeOfType<JObject>();
            json.Children().Count().ShouldBe(4);

            json["key"].ShouldBe("Project");
            json["name"].ShouldBe("Name");
            json["description"].ShouldBe("Description");
            json["publicAccess"].ShouldBe(true);
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var request = new RestRequest();

            var aspect = new CreateProjectCommandAspect();
            aspect.ApplyToRestRequest(request);

            request.Parameters.Count.ShouldBe(1);
            var jsonParameter = request.Parameters.TryFind(string.Empty).ShouldBeOfType<JsonParameter>();
            var json = jsonParameter.Value.ShouldBeOfType<JObject>();
            json.Children().Count().ShouldBe(3);

            json["key"].ShouldBe(JValue.CreateString(null));
            json["name"].ShouldBe(JValue.CreateString(null));
            json["publicAccess"].ShouldBe(false);
        }
    }
}
