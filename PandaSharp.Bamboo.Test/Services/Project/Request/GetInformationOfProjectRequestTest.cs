using System;
using System.Net;
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
    internal sealed class GetInformationOfProjectRequestTest
    {
        private const string ProjectKey = "ProjectX";
        
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<ProjectResponse>(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateRequest<GetInformationOfProjectRequest, ProjectResponse>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<ProjectResponse>(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateRequest<GetInformationOfProjectRequest, ProjectResponse>(restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var expandState = new Mock<IPlanListInformationExpansion>();
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock<ProjectResponse>();
            var resultCountParameterAspect = RequestTestMockBuilder.CreateParameterAspectMock<IResultCountParameterAspect>();

            var getInformationOfProjectRequestAspect = RequestTestMockBuilder.CreateParameterAspectMock<IGetInformationOfProjectRequestAspect>();
            getInformationOfProjectRequestAspect
                .Setup(i => i.IncludePlanInformation(It.IsAny<Action<IPlanListInformationExpansion>[]>()))
                .Callback<Action<IPlanListInformationExpansion>[]>(
                    expansions =>
                    {
                        foreach (var expansion in expansions)
                        {
                            expansion(expandState.Object);
                        }
                    });

            var request = RequestTestMockBuilder.CreateRequest<GetInformationOfProjectRequest, ProjectResponse>(restFactoryMock, resultCountParameterAspect, getInformationOfProjectRequestAspect);
            request.ProjectKey = ProjectKey;

            request
                .WithMaxResult(10)
                .StartAtIndex(5)
                .IncludePlanInformation(i => i.IncludeStages());

            var response = await request.ExecuteAsync();
            response.ShouldNotBeNull();
            
            restFactoryMock.Verify(r => r.CreateRequest($"project/{ProjectKey}", Method.GET), Times.Once);
            
            resultCountParameterAspect.Verify(i => i.SetMaxResults(10), Times.Once);
            resultCountParameterAspect.Verify(i => i.SetStartIndex(5), Times.Once);
            
            expandState.Verify(i => i.IncludeActions(), Times.Never);
            expandState.Verify(i => i.IncludeBranches(), Times.Never);
            expandState.Verify(i => i.IncludeStages(), Times.Once);
        }
    }
}