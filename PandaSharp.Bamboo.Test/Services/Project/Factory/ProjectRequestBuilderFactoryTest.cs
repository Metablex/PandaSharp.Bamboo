using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Bamboo.Services.Project.Factory;
using PandaSharp.Bamboo.Test.Framework.Services.Factory;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Project.Factory
{
    [TestFixture]
    internal sealed class ProjectRequestBuilderFactoryTest : RequestBuilderFactoryTestBase
    {
        private const string PlanKey = "MasterPlan";
        private const string ProjectKey = "ProjectX";
        private const string ProjectName = "ProjectName";

        [Test]
        public void GetAllProjectsTest()
        {
            SetupRequestRegistration<IGetAllProjectsRequest>(parameters => parameters.ShouldBeEmpty());

            var factory = new ProjectRequestBuilderFactory(Container.Object);
            var request = factory.GetAllProjects();

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void CreateProjectTest()
        {
            SetupRequestRegistration<ICreateProjectCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKey, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectName, ProjectName);
                });

            var factory = new ProjectRequestBuilderFactory(Container.Object);
            var request = factory.CreateProject(ProjectKey, ProjectName);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void DeleteProjectTest()
        {
            SetupRequestRegistration<IDeleteProjectCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(1);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKey, ProjectKey);
                });

            var factory = new ProjectRequestBuilderFactory(Container.Object);
            var request = factory.DeleteProject(ProjectKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void GetInformationOfProjectTest()
        {
            SetupRequestRegistration<IGetInformationOfProjectRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(1);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKey, ProjectKey);
                });

            var factory = new ProjectRequestBuilderFactory(Container.Object);
            var request = factory.GetInformationOfProject(ProjectKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }
    }
}