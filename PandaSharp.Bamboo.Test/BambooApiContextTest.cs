using System;
using Moq;
using NUnit.Framework;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Rest.Contract;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test
{
    [TestFixture]
    public sealed class BambooApiContextTest
    {
        [Test]
        public void GetCurrentApiVersionTest()
        {
            var responseMock = new Mock<IRestResponse>();
            responseMock
                .SetupGet(i => i.Content)
                .Returns(() => @"{ ""version"": ""1.2.3"" }");

            var restClientMock = new Mock<IRestClient>();
            restClientMock
                .Setup(i => i.Execute(It.IsAny<IRestRequest>()))
                .Returns(() => responseMock.Object);

            var restFactoryMock = new Mock<IRestFactory>();
            restFactoryMock
                .Setup(i => i.CreateClient())
                .Returns(() => restClientMock.Object);

            restFactoryMock
                .Setup(i => i.CreateRequest(It.IsAny<string>(), It.IsAny<Method>()))
                .Returns(() => new Mock<IRestRequest>().Object);

            var containerMock = new Mock<IPandaContainer>();
            containerMock
                .Setup(i => i.Resolve<IRestFactory>())
                .Returns(() => restFactoryMock.Object);

            var context = new BambooApiContext();
            context.GetCurrentApiVersion(containerMock.Object).ShouldBe(new Version(1, 2, 3));

            restFactoryMock.Verify(i => i.CreateRequest("info", Method.GET), Times.Once);
            restFactoryMock.Verify(i => i.CreateClient(), Times.Once);
            restFactoryMock.VerifyNoOtherCalls();

            context.GetCurrentApiVersion(containerMock.Object).ShouldBe(new Version(1, 2, 3));
            restFactoryMock.VerifyNoOtherCalls();
        }
    }
}