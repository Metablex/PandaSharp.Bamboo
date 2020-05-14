using System.Linq;
using Moq;
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
            var requestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            requestMock
                .Setup(i => i.AddJsonBody(It.IsAny<object>()))
                .Callback<object>(
                    obj =>
                    {
                        var json = obj.ShouldBeOfType<JObject>();
                        json.Children().Count().ShouldBe(4);

                        json["key"].ShouldBe("Project");
                        json["name"].ShouldBe("Name");
                        json["description"].ShouldBe("Description");
                        json["publicAccess"].ShouldBe(true);
                    })
                .Returns(requestMock.Object)
                .Verifiable();

            var aspect = new CreateProjectCommandAspect
            {
                ProjectKey = "Project",
                ProjectName = "Name",
                Description = "Description",
                EnablePublicAccess = true
            };
            aspect.ApplyToRestRequest(requestMock.Object);

            requestMock.Verify();
            requestMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DefaultParameterAspectTest()
        {
            var requestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            requestMock
                .Setup(i => i.AddJsonBody(It.IsAny<object>()))
                .Callback<object>(
                    obj =>
                    {
                        var json = obj.ShouldBeOfType<JObject>();
                        json.Children().Count().ShouldBe(3);

                        json["key"].ShouldBe(JValue.CreateString(null));
                        json["name"].ShouldBe(JValue.CreateString(null));
                        json["publicAccess"].ShouldBe(false);
                    })
                .Returns(requestMock.Object)
                .Verifiable();

            var aspect = new CreateProjectCommandAspect();
            aspect.ApplyToRestRequest(requestMock.Object);

            requestMock.Verify();
            requestMock.VerifyNoOtherCalls();
        }
    }
}