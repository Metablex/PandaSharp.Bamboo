using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Utils
{
    [TestFixture]
    public sealed class UnityContainerExtensionsTest
    {
        [Test]
        public void RegisterPandaModulesTest()
        {
            var containerMock = CreateContainerMock(@"{ ""version"": ""6.9.2"" }");
            containerMock.Object.RegisterPandaModules();
        }

        private Mock<IPandaContainer> CreateContainerMock(string bambooVersionResponse)
        {
            var restRequestMock = new Mock<IRestRequest>();

            var restResponseMock = new Mock<IRestResponse>();
            restResponseMock
                .SetupGet(r => r.Content)
                .Returns(bambooVersionResponse);

            var restClientMock = new Mock<IRestClient>();
            restClientMock
                .Setup(c => c.Execute(restRequestMock.Object))
                .Returns(restResponseMock.Object);

            var restFactoryMock = new Mock<IRestFactory>();
            restFactoryMock
                .Setup(f => f.CreateClient())
                .Returns(restClientMock.Object);

            restFactoryMock
                .Setup(f => f.CreateRequest("info", Method.GET))
                .Returns(restRequestMock.Object);

            var containerMock = new Mock<IPandaContainer>();
            containerMock
                .Setup(c => c.Resolve<IRestFactory>())
                .Returns(restFactoryMock.Object);

            return containerMock;
        }
    }
}