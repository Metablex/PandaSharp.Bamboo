using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Project.Aspect;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Bamboo.Services.Project.Request;
using PandaSharp.Bamboo.Services.Project.Response;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Project.Request
{
    [TestFixture]
    internal sealed class GetInformationOfRequestTest : RequestBaseTest<GetInformationOfRequest, ProjectResponse>
    {
        private const string ProjectKey = "ProjectX";

        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<IGetInformationOfRequestAspect>();
            yield return CreateParameterAspectMock<IResultCountParameterAspect>();
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            var response = await CreateRequest()
                .WithMaxResult(10)
                .StartAtIndex(5)
                .IncludePlanInformation()
                .ExecuteAsync();

            response.ShouldNotBeNull();
            VerifyRestRequestCreation($"project/{ProjectKey}", Method.GET);

            VerifyParameterAspectMock<IGetInformationOfRequestAspect>(aspect =>
            {
                aspect.IncludePlanInformation.ShouldBeTrue();
            });

            VerifyParameterAspectMock<IResultCountParameterAspect>(aspect =>
            {
                aspect.MaxResults.ShouldBe(10);
                aspect.StartIndex.ShouldBe(5);
            });
        }

        private new IGetInformationOfRequest CreateRequest()
        {
            var request = base.CreateRequest();
            request.ProjectKey = ProjectKey;

            return request;
        }
    }
}