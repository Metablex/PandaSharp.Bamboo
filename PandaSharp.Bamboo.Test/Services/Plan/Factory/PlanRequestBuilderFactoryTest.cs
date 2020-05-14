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
        public void GetAllPlansTest()
        {
            SetupRequestRegistration<IGetAllPlansRequest>(parameters => parameters.ShouldBeEmpty());

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.GetAllPlans();

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void GetInformationOfTest()
        {
            SetupRequestRegistration<IGetInformationOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKey, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKey, PlanKey);
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.GetInformationOf(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void GetBranchesOfTest()
        {
            SetupRequestRegistration<IGetBranchesOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKey, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKey, PlanKey);
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.GetBranchesOf(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void GetArtifactsOfTest()
        {
            SetupRequestRegistration<IGetArtifactsOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKey, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKey, PlanKey);
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.GetArtifactsOf(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void GetLabelsOfTest()
        {
            SetupRequestRegistration<IGetLabelsOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKey, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKey, PlanKey);
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.GetLabelsOf(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void GetVcsBranchesOfTest()
        {
            SetupRequestRegistration<IGetVcsBranchesOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKey, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKey, PlanKey);
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.GetVcsBranchesOf(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }

        [Test]
        public void AddLabelToPlanTest()
        {
            SetupRequestRegistration<IAddLabelToPlanCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKey, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKey, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.Label, "LabelMe");
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

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKey, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKey, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.Label, "LabelMe");
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

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKey, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKey, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.SetEnabled, true);
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

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKey, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKey, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.SetEnabled, false);
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

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKey, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKey, PlanKey);
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

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKey, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKey, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.Branch, "BranchTest");
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

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKey, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKey, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.SetFavourite, true);
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

                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.ProjectKey, ProjectKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.PlanKey, PlanKey);
                    ShouldContainInjectionProperty(parameters, RequestPropertyNames.SetFavourite, false);
                });

            var factory = new PlanRequestBuilderFactory(Container.Object);
            var request = factory.UnfavouritePlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            Container.Verify();
            Container.VerifyNoOtherCalls();
        }
    }
}