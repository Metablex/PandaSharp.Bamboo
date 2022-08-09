using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class GetLabelsOfPlanRequestTest
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<LabelListResponse>(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateRequest<GetLabelsOfPlanRequest, LabelListResponse>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<LabelListResponse>(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateRequest<GetLabelsOfPlanRequest, LabelListResponse>(restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task GetLabelsExecuteAsyncTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<LabelListResponse>();
            
            var request = RequestTestMockBuilder.CreateRequest<GetLabelsOfPlanRequest, LabelListResponse>(restFactoryMock);
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;
            
            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();
            
            restFactoryMock.Verify(r => r.CreateRequest($"plan/{ProjectKey}-{PlanKey}/label", Method.GET), Times.Once);
        }
    }
}