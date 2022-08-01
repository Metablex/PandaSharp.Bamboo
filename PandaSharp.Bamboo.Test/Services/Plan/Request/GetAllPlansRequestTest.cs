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
    internal sealed class GetAllPlansRequestTest
    {
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<PlanListResponse>(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateRequest<GetAllPlansRequest, PlanListResponse>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<PlanListResponse>(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateRequest<GetAllPlansRequest, PlanListResponse>(restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }
        
        [Test]
        public async Task ExecuteAsyncTest()
        {
            var expandState = new Mock<IPlanListInformationExpansion>();
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<PlanListResponse>();
            var resultCountParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<IResultCountParameterAspect>();
            
            var getAllPlansParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<IGetAllPlansParameterAspect>();
            getAllPlansParameterAspect
                .Setup(i => i.IncludePlanInformation(It.IsAny<Action<IPlanListInformationExpansion>[]>()))
                .Callback<Action<IPlanListInformationExpansion>[]>(
                    expansions =>
                    {
                        foreach (var expansion in expansions)
                        {
                            expansion(expandState.Object);
                        }
                    });

            var request = RequestTestMockBuilder
                .CreateRequest<GetAllPlansRequest, PlanListResponse>(restFactoryMock, resultCountParameterAspect, getAllPlansParameterAspect)
                .WithMaxResult(45)
                .StartAtIndex(7)
                .IncludePlanInformation(i =>
                {
                    i.IncludeStages();
                    i.IncludeActions();
                    i.IncludeBranches();
                });
            
            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();
            
            restFactoryMock.Verify(r => r.CreateRequest("plan", Method.GET), Times.Once);
            
            resultCountParameterAspect.Verify(i => i.SetMaxResults(45), Times.Once);
            resultCountParameterAspect.Verify(i => i.SetStartIndex(7), Times.Once);
            
            expandState.Verify(i => i.IncludeActions(), Times.Once);
            expandState.Verify(i => i.IncludeBranches(), Times.Once);
            expandState.Verify(i => i.IncludeStages(), Times.Once);
        }
    }
}