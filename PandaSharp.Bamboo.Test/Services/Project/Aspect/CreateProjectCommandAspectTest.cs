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
            var restRequestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            restRequestMock
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
                .Returns(restRequestMock.Object);

            var aspect = new CreateProjectCommandAspect();
            aspect.SetProjectKey("Project");
            aspect.SetProjectName("Name");
            aspect.SetDescription("Description");
            aspect.EnablePublicAccess(true);
            aspect.ApplyToRestRequest(restRequestMock.Object);

            restRequestMock.Verify(i => i.AddJsonBody(It.IsAny<object>()), Times.Once);
            restRequestMock.VerifyNoOtherCalls();
        }
        
        [Test]
        public void DefaultParameterAspectTest()
        {
            var restRequestMock = new Mock<IRestRequest>(MockBehavior.Strict);
            restRequestMock
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
                .Returns(restRequestMock.Object);

            var aspect = new CreateProjectCommandAspect();
            aspect.ApplyToRestRequest(restRequestMock.Object);

            restRequestMock.Verify(i => i.AddJsonBody(It.IsAny<object>()), Times.Once);
            restRequestMock.VerifyNoOtherCalls();
        }
    }
}