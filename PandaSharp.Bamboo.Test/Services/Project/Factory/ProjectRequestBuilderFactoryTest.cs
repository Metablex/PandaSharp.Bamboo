using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Bamboo.Services.Project.Factory;
using PandaSharp.Bamboo.Test.Framework.Services.Factory;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Project.Factory
{
    [TestFixture]
    internal sealed class ProjectRequestBuilderFactoryTest 
    {
        private const string ProjectKey = "ProjectX";
        private const string ProjectName = "ProjectName";

        [Test]
        public void GetAllProjectsTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetAllProjectsRequest>(parameters => parameters.ShouldBeEmpty());

            var factory = new ProjectRequestBuilderFactory(containerMock.Object);
            var request = factory.GetAllProjects();

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void CreateProjectTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<ICreateProjectCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectName && p.PropertyValue.Equals(ProjectName));
                });

            var factory = new ProjectRequestBuilderFactory(containerMock.Object);
            var request = factory.CreateProject(ProjectKey, ProjectName);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DeleteProjectTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IDeleteProjectCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(1);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                });

            var factory = new ProjectRequestBuilderFactory(containerMock.Object);
            var request = factory.DeleteProject(ProjectKey);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void GetInformationOfProjectTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetInformationOfProjectRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(1);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                });

            var factory = new ProjectRequestBuilderFactory(containerMock.Object);
            var request = factory.GetInformationOfProject(ProjectKey);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }
    }
}