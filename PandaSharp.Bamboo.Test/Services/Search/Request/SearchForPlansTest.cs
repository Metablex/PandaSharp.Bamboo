using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Search.Aspect;
using PandaSharp.Bamboo.Services.Search.Request;
using PandaSharp.Bamboo.Services.Search.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using PandaSharp.Framework.Services.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Search.Request
{
    [TestFixture]
    internal sealed class SearchForPlansTest : RequestBaseTest<SearchForPlansRequest, PlanSearchResultListResponse>
    {
        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<IResultCountParameterAspect>();
            yield return CreateParameterAspectMock<IPlanSearchParameterAspect>();
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var response = await CreateRequest().ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation("search/plans", Method.GET);
        }

        [Test]
        public void ResultCountParameterAspectTest()
        {
            CreateRequest()
                .WithMaxResult(42)
                .StartAtIndex(9);

            VerifyParameterAspectMock<IResultCountParameterAspect>(aspect =>
            {
                aspect.MaxResults.ShouldBe(42);
                aspect.StartIndex.ShouldBe(9);
            });
        }

        [Test]
        public void PlanSearchParameterAspectTest()
        {
            CreateRequest()
                .WithSearchTerm("Test")
                .PerformFuzzySearch();

            VerifyParameterAspectMock<IPlanSearchParameterAspect>(aspect =>
            {
                aspect.SearchTerm.ShouldBe("Test");
                aspect.PerformFuzzySearch.ShouldBeTrue();
            });
        }
    }
}