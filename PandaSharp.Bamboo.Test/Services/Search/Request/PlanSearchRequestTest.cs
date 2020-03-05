using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Search.Aspect;
using PandaSharp.Bamboo.Services.Search.Request;
using PandaSharp.Bamboo.Services.Search.Response;
using PandaSharp.Bamboo.Test.Services.Common.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Search.Request
{
    [TestFixture]
    internal sealed class PlanSearchRequestTest : RequestBaseTest<PlanSearchRequest, PlanSearchResultListResponse>
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
        public void RequestOptionsTest()
        {
            CreateRequest()
                .WithMaxResult(42)
                .StartAtIndex(9)
                .WithSearchTerm("Test")
                .PerformFuzzySearch();

            ValidateParameterAspectMock<IResultCountParameterAspect>(aspect =>
            {
                aspect.MaxResults.ShouldBe(42);
                aspect.StartIndex.ShouldBe(9);
            });

            ValidateParameterAspectMock<IPlanSearchParameterAspect>(aspect =>
            {
                aspect.SearchTerm.ShouldBe("Test");
                aspect.PerformFuzzySearch.ShouldBeTrue();
            });
        }
    }
}