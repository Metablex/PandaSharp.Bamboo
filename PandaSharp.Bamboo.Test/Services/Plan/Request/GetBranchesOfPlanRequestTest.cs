using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class GetBranchesOfPlanRequestTest
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<BranchListResponse>(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateRequest<GetBranchesOfPlanRequest, BranchListResponse>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<BranchListResponse>(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateRequest<GetBranchesOfPlanRequest, BranchListResponse>(restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<BranchListResponse>();
            var resultCountParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<IResultCountParameterAspect>();
            var getBranchesOfPlanParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<IGetBranchesOfPlanParameterAspect>();

            var request = RequestTestMockBuilder.CreateRequest<GetBranchesOfPlanRequest, BranchListResponse>(restFactoryMock, resultCountParameterAspect, getBranchesOfPlanParameterAspect);
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;

            request
                .WithMaxResult(12)
                .StartAtIndex(3)
                .OnlyEnabledBranches();
            
            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();
            
            restFactoryMock.Verify(r => r.CreateRequest($"plan/{ProjectKey}-{PlanKey}/branch", Method.GET), Times.Once);
            
            resultCountParameterAspect.Verify(i => i.SetMaxResults(12), Times.Once);
            resultCountParameterAspect.Verify(i => i.SetStartIndex(3), Times.Once);
            getBranchesOfPlanParameterAspect.Verify(i => i.SetOnlyEnabledBranchesFilter(true), Times.Once);
        }
    }
}