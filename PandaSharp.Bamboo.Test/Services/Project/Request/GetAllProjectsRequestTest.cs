using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Plan.Expansion;
using PandaSharp.Bamboo.Services.Project.Aspect;
using PandaSharp.Bamboo.Services.Project.Request;
using PandaSharp.Bamboo.Services.Project.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Project.Request
{
    [TestFixture]
    internal sealed class GetAllProjectsRequestTest : RequestBaseTest<GetAllProjectsRequest, ProjectListResponse>
    {
        private Mock<IPlanListInformationExpansion> _expandState;

        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<IGetAllProjectsParameterAspect>(
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
            var response = await CreateRequest()
                .IncludeEmptyProjects()
                .IncludePlanInformation(i => i.IncludeBranches())
                .ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation("project", Method.GET);

            VerifyParameterAspectMock<IGetAllProjectsParameterAspect>(aspect =>
            {
                aspect.IncludeEmptyProjects.ShouldBeTrue();

                _expandState.Verify(i => i.IncludeActions(), Times.Never);
                _expandState.Verify(i => i.IncludeBranches(), Times.Once);
                _expandState.Verify(i => i.IncludeStages(), Times.Never);
            });
        }
    }
}