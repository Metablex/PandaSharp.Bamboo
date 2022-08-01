using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class GetInformationOfPlanRequestTest
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<PlanResponse>(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateRequest<GetInformationOfPlanRequest, PlanResponse>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<PlanResponse>(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateRequest<GetInformationOfPlanRequest, PlanResponse>(restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var expandState = new Mock<IPlanInformationExpansion>();
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<PlanResponse>();
            var resultCountParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<IResultCountParameterAspect>();
            
            var getInformationOfPlanParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<IGetInformationOfPlanParameterAspect>();
            getInformationOfPlanParameterAspect
                .Setup(i => i.IncludePlanInformation(It.IsAny<Action<IPlanInformationExpansion>[]>()))
                .Callback<Action<IPlanInformationExpansion>[]>(
                    expansions =>
                    {
                        foreach (var expansion in expansions)
                        {
                            expansion(expandState.Object);
                        }
                    });

            var request = RequestTestMockBuilder.CreateRequest<GetInformationOfPlanRequest, PlanResponse>(restFactoryMock, resultCountParameterAspect, getInformationOfPlanParameterAspect);
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;
                
            request
                .WithMaxBranchResults(30)
                .IncludePlanInformation(
                    i =>
                    {
                        i.IncludeActions();
                        i.IncludeBranches();
                        i.IncludeStages();
                        i.IncludeVariableContext();
                    });
            
            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();
            
            restFactoryMock.Verify(r => r.CreateRequest($"plan/{ProjectKey}-{PlanKey}", Method.GET), Times.Once);
            
            resultCountParameterAspect.Verify(i => i.SetMaxResults(30), Times.Once);
            resultCountParameterAspect.Verify(i => i.SetStartIndex(It.IsAny<int>()), Times.Never);
            
            expandState.Verify(i => i.IncludeActions(), Times.Once);
            expandState.Verify(i => i.IncludeStages(), Times.Once);
            expandState.Verify(i => i.IncludeVariableContext(), Times.Once);
            expandState.Verify(i => i.IncludeBranches(), Times.Once);
        }
    }
}