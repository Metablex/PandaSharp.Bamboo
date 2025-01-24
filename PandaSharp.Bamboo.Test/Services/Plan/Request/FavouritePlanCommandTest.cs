using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class FavouritePlanCommandTest
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";

        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateCommand<FavouritePlanCommand>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateCommand<FavouritePlanCommand>(restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task FavouriteExecuteAsyncTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock();

            var command = RequestTestMockBuilder.CreateCommand<FavouritePlanCommand>(restFactoryMock);
            command.ProjectKey = ProjectKey;
            command.PlanKey = PlanKey;
            command.SetFavourite = true;
            await command.ExecuteAsync();

            restFactoryMock.Verify(i => i.CreateRequest($"plan/{ProjectKey}-{PlanKey}/favourite", Method.Post), Times.Once);
        }

        [Test]
        public async Task UnfavouriteExecuteAsyncTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock();

            var command = RequestTestMockBuilder.CreateCommand<FavouritePlanCommand>(restFactoryMock);
            command.ProjectKey = ProjectKey;
            command.PlanKey = PlanKey;
            command.SetFavourite = false;
            await command.ExecuteAsync();

            restFactoryMock.Verify(i => i.CreateRequest($"plan/{ProjectKey}-{PlanKey}/favourite", Method.Delete), Times.Once);
        }
    }
}
