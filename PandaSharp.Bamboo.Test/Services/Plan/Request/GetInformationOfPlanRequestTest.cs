using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Services.Plan.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class GetInformationOfPlanRequestTest : RequestBaseTest<GetInformationOfPlanRequest, PlanResponse>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";

        private Mock<IPlanInformationExpansion> _expandState;

        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<IResultCountParameterAspect>();
            yield return CreateParameterAspectMock<IGetInformationOfPlanParameterAspect>(
                aspect =>
                {
                    aspect
                        .Setup(i => i.IncludePlanInformation(It.IsAny<Action<IPlanInformationExpansion>[]>()))
                        .Callback<Action<IPlanInformationExpansion>[]>(
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
            _expandState = new Mock<IPlanInformationExpansion>();
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var response = await CreateRequest().ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation($"plan/{ProjectKey}-{PlanKey}", Method.GET);
        }

        [Test]
        public void ExpandStateParameterAspectTest()
        {
            CreateRequest()
                .WithMaxBranchResults(30)
                .IncludePlanInformation(
                    i =>
                    {
                        i.IncludeActions();
                        i.IncludeBranches();
                        i.IncludeStages();
                        i.IncludeVariableContext();
                    });

            VerifyParameterAspectMock<IGetInformationOfPlanParameterAspect>(aspect =>
            {
                _expandState.Verify(i => i.IncludeActions(), Times.Once);
                _expandState.Verify(i => i.IncludeStages(), Times.Once);
                _expandState.Verify(i => i.IncludeVariableContext(), Times.Once);
                _expandState.Verify(i => i.IncludeBranches(), Times.Once);
            });

            VerifyParameterAspectMock<IResultCountParameterAspect>(aspect =>
            {
                aspect.MaxResults.ShouldBe(30);
                aspect.StartIndex.ShouldBeNull();
            });
        }

        private new IGetInformationOfPlanRequest CreateRequest()
        {
            var request = base.CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;

            return request;
        }
    }
}