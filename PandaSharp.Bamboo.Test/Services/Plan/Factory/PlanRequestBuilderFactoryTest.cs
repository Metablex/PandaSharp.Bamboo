using System;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Factory;
using PandaSharp.Bamboo.Test.Framework.Services.Factory;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Factory
{
    [TestFixture]
    internal sealed class PlanRequestBuilderFactoryTest : RequestBuilderFactoryTestBase
    {
        private const string PlanKey = "MasterPlan";
        private const string ProjectKey = "ProjectX";

        [Test]
        public void AllPlansTest()
        {
            SetupRequestRegistration<IAllPlansRequest>(parameters => parameters.ShouldBeEmpty());

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.AllPlans();

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void InformationOfTest()
        {
            SetupRequestRegistration<IInformationOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.InformationOf(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void BranchesOfTest()
        {
            SetupRequestRegistration<IBranchesOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.BranchesOf(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void ArtifactsOfTest()
        {
            SetupRequestRegistration<IArtifactsOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.ArtifactsOf(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void LabelsOfTest()
        {
            SetupRequestRegistration<ILabelsOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.LabelsOf(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void VcsBranchesOfTest()
        {
            SetupRequestRegistration<IVcsBranchesOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.VcsBranchesOf(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void AddLabelToPlanTest()
        {
            SetupRequestRegistration<ILabelsOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.LabelName, "LabelMe");
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.AddLabelToPlan(ProjectKey, PlanKey, "LabelMe");

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void DeleteLabelOfPlanTest()
        {
            SetupRequestRegistration<IDeleteLabelOfPlanCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.LabelName, "LabelMe");
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.DeleteLabelOfPlan(ProjectKey, PlanKey, "LabelMe");

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void EnablePlanTest()
        {
            SetupRequestRegistration<IEnableDisablePlanCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.SetEnabledName, true);
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.EnablePlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void DisablePlanTest()
        {
            SetupRequestRegistration<IEnableDisablePlanCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.SetEnabledName, false);
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.DisablePlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void DeletePlanTest()
        {
            SetupRequestRegistration<IDeletePlanCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.DeletePlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void CreateBranchTest()
        {
            SetupRequestRegistration<ICreatePlanCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.BranchName, "BranchTest");
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            Should.Throw<ArgumentException>(() => factory.CreateBranch(ProjectKey, PlanKey, "BranchTest/Broken"));

            var request = factory.CreateBranch(ProjectKey, PlanKey, "BranchTest");

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void FavouritePlanTest()
        {
            SetupRequestRegistration<IFavouritePlanCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.SetFavouriteName, true);
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.FavouritePlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void UnfavouritePlanTest()
        {
            SetupRequestRegistration<IFavouritePlanCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKeyName, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKeyName, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.SetFavouriteName, false);
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.UnfavouritePlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }
    }
}