using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Project.Aspect;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Bamboo.Services.Project.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Project.Request
{
    [TestFixture]
    internal sealed class CreateProjectCommandTest : CommandBaseTest<CreateProjectCommand>
    {
        private const string ProjectKey = "ProjectX";
        private const string ProjectName = "ProjectName";
        private const string Description = "Test";

        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<ICreateProjectCommandAspect>();
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            await CreateCommand()
                .WithDescription(Description)
                .EnablePublicAccess()
                .ExecuteAsync();

            VerifyRestRequestCreation("project", Method.POST);

            VerifyParameterAspectMock<ICreateProjectCommandAspect>(aspect =>
            {
                aspect.ProjectKey.ShouldBe(ProjectKey);
                aspect.ProjectName.ShouldBe(ProjectName);
                aspect.Description.ShouldBe(Description);
                aspect.EnablePublicAccess.ShouldBeTrue();
            });
        }

        private ICreateProjectCommand CreateCommand()
        {
            var request = CreateRequest();
            request.ProjectKey = ProjectKey;
            request.ProjectName = ProjectName;

            return request;
        }
    }
}