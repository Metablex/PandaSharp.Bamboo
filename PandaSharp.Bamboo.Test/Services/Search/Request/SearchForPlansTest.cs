using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Search.Aspect;
using PandaSharp.Bamboo.Services.Search.Request;
using PandaSharp.Bamboo.Services.Search.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Search.Request
{
    [TestFixture]
    internal sealed class SearchForPlansTest
    {
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<PlanSearchResultListResponse>(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateRequest<SearchForPlansRequest, PlanSearchResultListResponse>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<PlanSearchResultListResponse>(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateRequest<SearchForPlansRequest, PlanSearchResultListResponse>(restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<PlanSearchResultListResponse>();
            var resultCountParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<IResultCountParameterAspect>();
            var planSearchParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<IPlanSearchParameterAspect>();

            var request = RequestTestMockBuilder
                .CreateRequest<SearchForPlansRequest, PlanSearchResultListResponse>(restFactoryMock, resultCountParameterAspect, planSearchParameterAspect)
                .WithMaxResult(42)
                .StartAtIndex(9)
                .WithSearchTerm("Test")
                .PerformFuzzySearch();

            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();

            restFactoryMock.Verify(r => r.CreateRequest("search/plans", Method.Get), Times.Once);

            resultCountParameterAspect.Verify(i => i.SetMaxResults(42), Times.Once);
            resultCountParameterAspect.Verify(i => i.SetStartIndex(9), Times.Once);

            planSearchParameterAspect.Verify(i => i.SetSearchTerm("Test"), Times.Once);
            planSearchParameterAspect.Verify(i => i.SetPerformFuzzySearch(true), Times.Once);
        }
    }
}
