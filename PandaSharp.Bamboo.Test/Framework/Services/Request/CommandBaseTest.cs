using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Framework.Services.Request
{
    [TestFixture]
    internal abstract class CommandBaseTest<TCommand> : RestCommunicationTestBase<TCommand>
        where TCommand : CommandBase
    {
        [Test]
        [TestRequestStatusCode(HttpStatusCode.Unauthorized)]
        public void UnauthorizedExecuteTest()
        {
            var request = CreateRequest();

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        [TestRequestStatusCode(HttpStatusCode.NotFound)]
        public void AnyErrorWhileExecuteTest()
        {
            var request = CreateRequest();

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public void GetCommandUriTest()
        {
            var request = CreateRequest();
            var uri = request.GetCommandUri();

            uri.ShouldNotBeNull();
            uri.AbsoluteUri.ShouldBe("https://testme.com/resource");
        }

        protected override Mock<IRestClient> SetupRestClientMock()
        {
            var response = new Mock<IRestResponse>(MockBehavior.Loose);
            response
                .SetupGet(i => i.IsSuccessful)
                .Returns(IsResponseSuccessful);

            response
                .SetupGet(i => i.StatusCode)
                .Returns(GetResponseStatusCode);

            response
                .SetupGet(i => i.ErrorMessage)
                .Returns(GetResponseErrorMessage);

            var client = new Mock<IRestClient>(MockBehavior.Strict);
            client
                .Setup(i => i.ExecuteTaskAsync(It.IsAny<IRestRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.Run(() => response.Object));

            client
                .Setup(i => i.BuildUri(It.IsAny<IRestRequest>()))
                .Returns<IRestRequest>(request => new Uri("https://testme.com/resource"));

            return client;
        }
    }
}