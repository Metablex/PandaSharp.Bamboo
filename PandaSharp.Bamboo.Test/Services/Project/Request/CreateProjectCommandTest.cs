using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Project.Aspect;
using PandaSharp.Bamboo.Services.Project.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Project.Request
{
    [TestFixture]
    internal sealed class CreateProjectCommandTest
    {
        private const string ProjectKey = "ProjectX";
        private const string ProjectName = "ProjectName";
        private const string Description = "Test";
        
        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateCommand<CreateProjectCommand>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateCommand<CreateProjectCommand>(restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }
        
        [Test]
        public async Task ExecuteAsyncTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock();
            var aspect = RequestTestMockBuilder.CreateParameterAspectMock<ICreateProjectCommandAspect>();
            
            var command = RequestTestMockBuilder.CreateCommand<CreateProjectCommand>(restFactoryMock, aspect);
            command.ProjectKey = ProjectKey;
            command.ProjectName = ProjectName;
            command
                .WithDescription(Description)
                .EnablePublicAccess();
                
            await command.ExecuteAsync();

            restFactoryMock.Verify(i => i.CreateRequest("project", Method.POST), Times.Once);

            aspect.Verify(i => i.SetProjectKey(ProjectKey), Times.Once);
            aspect.Verify(i => i.SetProjectName(ProjectName), Times.Once);
            aspect.Verify(i => i.SetDescription(Description), Times.Once);
            aspect.Verify(i => i.EnablePublicAccess(true), Times.Once);
        }
    }
}