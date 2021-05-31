using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Expansion;
using PandaSharp.Bamboo.Services.Build.Request;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using PandaSharp.Framework.Services.Aspect;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Request
{
    [TestFixture]
    internal sealed class GetInformationOfBuildRequestTest : RequestBaseTest<GetInformationOfBuildRequest, BuildResponse>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const uint BuildNumber = 42;

        private Mock<IBuildInformationExpansion> _expandState;

        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<IGetInformationOfBuildParameterAspect>(
                aspect =>
                {
                    aspect
                        .Setup(i => i.IncludeBuildInformation(It.IsAny<Action<IBuildInformationExpansion>[]>()))
                        .Callback<Action<IBuildInformationExpansion>[]>(
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
            _expandState = new Mock<IBuildInformationExpansion>();
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var response = await CreateRequest().ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation($"result/{ProjectKey}-{PlanKey}-{BuildNumber}", Method.GET);
        }

        [Test]
        public void ExpandStateParameterAspectTest()
        {
            CreateRequest()
                .IncludeBuildInformation(
                    i => i.IncludingArtifacts(),
                    i => i.IncludingJiraIssues());

            VerifyParameterAspectMock<IGetInformationOfBuildParameterAspect>(aspect =>
            {
                _expandState.Verify(i => i.IncludingArtifacts(), Times.Once);
                _expandState.Verify(i => i.IncludingComments(), Times.Never);
                _expandState.Verify(i => i.IncludingLabels(), Times.Never);
                _expandState.Verify(i => i.IncludingStages(), Times.Never);
                _expandState.Verify(i => i.IncludingVariables(), Times.Never);
                _expandState.Verify(i => i.IncludingJiraIssues(), Times.Once);
                _expandState.Verify(i => i.IncludingChanges(), Times.Never);
                _expandState.Verify(i => i.IncludingMetaData(), Times.Never);
            });
        }

        private new IGetInformationOfBuildRequest CreateRequest()
        {
            var request = base.CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;
            request.BuildNumber = BuildNumber;

            return request;
        }
    }
}