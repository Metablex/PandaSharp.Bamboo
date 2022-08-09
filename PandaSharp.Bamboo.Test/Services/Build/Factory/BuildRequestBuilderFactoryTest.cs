using NUnit.Framework;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Factory;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Test.Framework.Services.Factory;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Build.Factory
{
    [TestFixture]
    internal sealed class BuildRequestBuilderFactoryTest
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const uint BuildNumber = 42;
        private const string Label = "BlackLabel";
        private const string Comment = "Comment";

        [Test]
        public void GetAllBuildsTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetBuildsOfPlanRequest>(parameters => parameters.ShouldBeEmpty());

            var factory = new BuildRequestBuilderFactory(containerMock.Object);
            var request = factory.GetAllBuilds();

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void GetBuildsOfPlanTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetBuildsOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                });

            var factory = new BuildRequestBuilderFactory(containerMock.Object);
            var request = factory.GetBuildsOfPlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void GetInformationOfBuildTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetInformationOfBuildRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.BuildNumber && p.PropertyValue.Equals(BuildNumber));
                });

            var factory = new BuildRequestBuilderFactory(containerMock.Object);
            var request = factory.GetInformationOfBuild(ProjectKey, PlanKey, BuildNumber);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void GetInformationOfLatestBuildTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetInformationOfBuildRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.BuildNumber && p.PropertyValue.Equals("latest"));
                });

            var factory = new BuildRequestBuilderFactory(containerMock.Object);
            var request = factory.GetInformationOfLatestBuild(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void GetCommentsOfBuildTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetCommentsOfBuildRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.BuildNumber && p.PropertyValue.Equals(BuildNumber));
                });

            var factory = new BuildRequestBuilderFactory(containerMock.Object);
            var request = factory.GetCommentsOfBuild(ProjectKey, PlanKey, BuildNumber);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void GetLabelsOfBuildTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetLabelsOfBuildRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.BuildNumber && p.PropertyValue.Equals(BuildNumber));
                });

            var factory = new BuildRequestBuilderFactory(containerMock.Object);
            var request = factory.GetLabelsOfBuild(ProjectKey, PlanKey, BuildNumber);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void AddCommentToBuildTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IAddCommentToBuildCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(4);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.BuildNumber && p.PropertyValue.Equals(BuildNumber));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.Comment && p.PropertyValue.Equals(Comment));
                });

            var factory = new BuildRequestBuilderFactory(containerMock.Object);
            var request = factory.AddCommentToBuild(ProjectKey, PlanKey, BuildNumber, Comment);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void AddLabelToBuildTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IAddLabelToBuildCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(4);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.BuildNumber && p.PropertyValue.Equals(BuildNumber));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.Label && p.PropertyValue.Equals(Label));
                });

            var factory = new BuildRequestBuilderFactory(containerMock.Object);
            var request = factory.AddLabelToBuild(ProjectKey, PlanKey, BuildNumber, Label);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DeleteLabelOfBuildTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IDeleteLabelOfBuildCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(4);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.BuildNumber && p.PropertyValue.Equals(BuildNumber));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.Label && p.PropertyValue.Equals(Label));
                });

            var factory = new BuildRequestBuilderFactory(containerMock.Object);
            var request = factory.DeleteLabelOfBuild(ProjectKey, PlanKey, BuildNumber, Label);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }
    }
}