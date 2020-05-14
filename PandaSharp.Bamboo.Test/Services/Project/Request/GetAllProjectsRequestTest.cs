using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
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
        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<IGetAllProjectsParameterAspect>();
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var response = await CreateRequest()
                .IncludeEmptyProjects()
                .IncludePlanInformation()
                .ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation("project", Method.GET);

            VerifyParameterAspectMock<IGetAllProjectsParameterAspect>(aspect =>
            {
                aspect.IncludeEmptyProjects.ShouldBeTrue();
                aspect.IncludePlanInformation.ShouldBeTrue();
            });
        }
    }
}