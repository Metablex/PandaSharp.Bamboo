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

        [Test]
        public void AllBuildsTest()
        {
            SetupRequestRegistration<IMultipleBuildsRequest>(parameters => parameters.ShouldBeEmpty());

            var factory = new BuildRequestBuilderFactory(Container.Object);
            var request = factory.AllBuilds();

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void BuildsOfPlanTest()
        {
            SetupRequestRegistration<IMultipleBuildsRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                });

            var factory = new BuildRequestBuilderFactory(Container.Object);
            var request = factory.BuildsOfPlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void InformationOfBuildTest()
        {
            SetupRequestRegistration<ISingleBuildRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.BuildNumberName, BuildNumber);
                });

            var factory = new BuildRequestBuilderFactory(Container.Object);
            var request = factory.InformationOfBuild(ProjectKey, PlanKey, BuildNumber);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void InformationOfLatestBuildTest()
        {
            SetupRequestRegistration<ISingleBuildRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.BuildNumberName, "latest");
                });

            var factory = new BuildRequestBuilderFactory(Container.Object);
            var request = factory.InformationOfLatestBuild(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void CommentsOfBuildTest()
        {
            SetupRequestRegistration<ICommentsOfBuildRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.BuildNumberName, BuildNumber);
                });

            var factory = new BuildRequestBuilderFactory(Container.Object);
            var request = factory.CommentsOfBuild(ProjectKey, PlanKey, BuildNumber);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void LabelsOfBuildTest()
        {
            SetupRequestRegistration<ILabelsOfBuildRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.BuildNumberName, BuildNumber);
                });

            var factory = new BuildRequestBuilderFactory(Container.Object);
            var request = factory.LabelsOfBuild(ProjectKey, PlanKey, BuildNumber);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }
    }
}