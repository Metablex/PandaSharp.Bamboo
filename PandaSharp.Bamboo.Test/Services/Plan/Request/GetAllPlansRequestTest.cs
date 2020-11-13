using System;
using System.Collections.Generic;
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
    internal sealed class GetAllPlansRequestTest : RequestBaseTest<GetAllPlansRequest, PlanListResponse>
    {
        private Mock<IPlanListInformationExpansion> _expandState;

        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<IResultCountParameterAspect>();
            yield return CreateParameterAspectMock<IGetAllPlansParameterAspect>(
                aspect =>
                {
                    aspect
                        .Setup(i => i.IncludePlanInformation(It.IsAny<Action<IPlanListInformationExpansion>[]>()))
                        .Callback<Action<IPlanListInformationExpansion>[]>(
                            expansions =>
                            {
                                foreach (var expansion in expansions)
                                {
                                    expansion(_expandState.Object);
                                }
                            });
                });
        }

        protected override void SetupEachTest()
        {
            _expandState = new Mock<IPlanListInformationExpansion>();
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var response = await CreateRequest().ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation("plan", Method.GET);
        }

        [Test]
        public void ResultCountParameterAspectOptionsTest()
        {
            CreateRequest()
                .WithMaxResult(45)
                .StartAtIndex(7);

            VerifyParameterAspectMock<IResultCountParameterAspect>(aspect =>
            {
                aspect.MaxResults.ShouldBe(45);
                aspect.StartIndex.ShouldBe(7);
            });
        }

        [Test]
        public void GetAllPlansParameterAspectTest()
        {
            CreateRequest().IncludePlanInformation();

            VerifyParameterAspectMock<IGetAllPlansParameterAspect>(aspect =>
            {
                _expandState.Verify(i => i.IncludeActions(), Times.Never);
                _expandState.Verify(i => i.IncludeBranches(), Times.Never);
                _expandState.Verify(i => i.IncludeStages(), Times.Never);
            });

            CreateRequest()
                .IncludePlanInformation(
                    i =>
                    {
                        i.IncludeStages();
                        i.IncludeActions();
                        i.IncludeBranches();
                    });

            VerifyParameterAspectMock<IGetAllPlansParameterAspect>(aspect =>
            {
                _expandState.Verify(i => i.IncludeActions(), Times.Once);
                _expandState.Verify(i => i.IncludeBranches(), Times.Once);
                _expandState.Verify(i => i.IncludeStages(), Times.Once);
            });
        }
    }
}