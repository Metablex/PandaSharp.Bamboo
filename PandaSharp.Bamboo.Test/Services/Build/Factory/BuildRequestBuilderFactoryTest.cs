using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Factory;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Test.Framework.Services.Factory;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Factory
{
    [TestFixture]
    internal sealed class BuildRequestBuilderFactoryTest : RequestBuilderFactoryTestBase
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const uint BuildNumber = 42;
        private const string Label = "BlackLabel";
        private const string Comment = "Comment";

        [Test]
        public void GetAllBuildsTest()
        {
            SetupRequestRegistration<IGetBuildsOfPlanRequest>(parameters => parameters.ShouldBeEmpty());

            var factory = new BuildRequestBuilderFactory(Container.Object);
            var request = factory.GetAllBuilds();

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void GetBuildsOfPlanTest()
        {
            SetupRequestRegistration<IGetBuildsOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                });

            var factory = new BuildRequestBuilderFactory(Container.Object);
            var request = factory.GetBuildsOfPlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void GetInformationOfBuildTest()
        {
            SetupRequestRegistration<IGetInformationOfBuildRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.BuildNumberName, BuildNumber);
                });

            var factory = new BuildRequestBuilderFactory(Container.Object);
            var request = factory.GetInformationOfBuild(ProjectKey, PlanKey, BuildNumber);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void GetInformationOfLatestBuildTest()
        {
            SetupRequestRegistration<IGetInformationOfBuildRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.BuildNumberName, "latest");
                });

            var factory = new BuildRequestBuilderFactory(Container.Object);
            var request = factory.GetInformationOfLatestBuild(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void GetCommentsOfBuildTest()
        {
            SetupRequestRegistration<IGetCommentsOfBuildRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.BuildNumberName, BuildNumber);
                });

            var factory = new BuildRequestBuilderFactory(Container.Object);
            var request = factory.GetCommentsOfBuild(ProjectKey, PlanKey, BuildNumber);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void GetLabelsOfBuildTest()
        {
            SetupRequestRegistration<IGetLabelsOfBuildRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.BuildNumberName, BuildNumber);
                });

            var factory = new BuildRequestBuilderFactory(Container.Object);
            var request = factory.GetLabelsOfBuild(ProjectKey, PlanKey, BuildNumber);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void AddCommentToBuildTest()
        {
            SetupRequestRegistration<IAddCommentToBuildCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(4);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.BuildNumberName, BuildNumber);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.Comment, Comment);
                });

            var factory = new BuildRequestBuilderFactory(Container.Object);
            var request = factory.AddCommentToBuild(ProjectKey, PlanKey, BuildNumber, Comment);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void AddLabelToBuildTest()
        {
            SetupRequestRegistration<IAddLabelToBuildCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(4);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.BuildNumberName, BuildNumber);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.LabelName, Label);
                });

            var factory = new BuildRequestBuilderFactory(Container.Object);
            var request = factory.AddLabelToBuild(ProjectKey, PlanKey, BuildNumber, Label);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void DeleteLabelOfBuildTest()
        {
            SetupRequestRegistration<IDeleteLabelOfBuildCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(4);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.BuildNumberName, BuildNumber);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.LabelName, Label);
                });

            var factory = new BuildRequestBuilderFactory(Container.Object);
            var request = factory.DeleteLabelOfBuild(ProjectKey, PlanKey, BuildNumber, Label);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }
    }
}