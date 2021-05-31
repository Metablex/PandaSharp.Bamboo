using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Bamboo.Services.Project.Aspect;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Bamboo.Services.Project.Request;
using PandaSharp.Bamboo.Services.Project.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using PandaSharp.Framework.Services.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Project.Request
{
    [TestFixture]
    internal sealed class GetInformationOfProjectRequestTest : RequestBaseTest<GetInformationOfProjectRequest, ProjectResponse>
    {
        private const string ProjectKey = "ProjectX";

        private Mock<IPlanListInformationExpansion> _expandState;

        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<IGetInformationOfProjectRequestAspect>(
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

            yield return CreateParameterAspectMock<IResultCountParameterAspect>();
        }

        protected override void SetupEachTest()
        {
            _expandState = new Mock<IPlanListInformationExpansion>();
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var response = await CreateRequest()
                .WithMaxResult(10)
                .StartAtIndex(5)
                .IncludePlanInformation(i => i.IncludeStages())
                .ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation($"project/{ProjectKey}", Method.GET);

            VerifyParameterAspectMock<IGetInformationOfProjectRequestAspect>(aspect =>
            {
                _expandState.Verify(i => i.IncludeActions(), Times.Never);
                _expandState.Verify(i => i.IncludeBranches(), Times.Never);
                _expandState.Verify(i => i.IncludeStages(), Times.Once);
            });

            VerifyParameterAspectMock<IResultCountParameterAspect>(aspect =>
            {
                aspect.MaxResults.ShouldBe(10);
                aspect.StartIndex.ShouldBe(5);
            });
        }

        private new IGetInformationOfProjectRequest CreateRequest()
        {
            var request = base.CreateRequest();
            request.ProjectKey = ProjectKey;

            return request;
        }
    }
}