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
    internal sealed class PlanRequestBuilderFactoryTest
    {
        private const string PlanKey = "MasterPlan";
        private const string ProjectKey = "ProjectX";

        [Test]
        public void GetAllPlansTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetAllPlansRequest>(parameters => parameters.ShouldBeEmpty());

            var factory = new PlanRequestBuilderFactory(containerMock.Object);
            var request = factory.GetAllPlans();

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void GetInformationOfPlanTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetInformationOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                });

            var factory = new PlanRequestBuilderFactory(containerMock.Object);
            var request = factory.GetInformationOfPlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void GetBranchesOfPlanTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetBranchesOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                });

            var factory = new PlanRequestBuilderFactory(containerMock.Object);
            var request = factory.GetBranchesOfPlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void GetArtifactsOfPlanTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetArtifactsOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                });

            var factory = new PlanRequestBuilderFactory(containerMock.Object);
            var request = factory.GetArtifactsOfPlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void GetLabelsOfPlanTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetLabelsOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                });

            var factory = new PlanRequestBuilderFactory(containerMock.Object);
            var request = factory.GetLabelsOfPlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void GetVcsBranchesOfPlanTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IGetVcsBranchesOfPlanRequest>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                });

            var factory = new PlanRequestBuilderFactory(containerMock.Object);
            var request = factory.GetVcsBranchesOfPlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void AddLabelToPlanTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IAddLabelToPlanCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.Label && p.PropertyValue.Equals("LabelMe"));
                });

            var factory = new PlanRequestBuilderFactory(containerMock.Object);
            var request = factory.AddLabelToPlan(ProjectKey, PlanKey, "LabelMe");

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DeleteLabelOfPlanTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IDeleteLabelOfPlanCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.Label && p.PropertyValue.Equals("LabelMe"));
                });

            var factory = new PlanRequestBuilderFactory(containerMock.Object);
            var request = factory.DeleteLabelOfPlan(ProjectKey, PlanKey, "LabelMe");

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void EnablePlanTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IEnableDisablePlanCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.SetEnabled && p.PropertyValue.Equals(true));
                });

            var factory = new PlanRequestBuilderFactory(containerMock.Object);
            var request = factory.EnablePlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DisablePlanTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IEnableDisablePlanCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.SetEnabled && p.PropertyValue.Equals(false));
                });

            var factory = new PlanRequestBuilderFactory(containerMock.Object);
            var request = factory.DisablePlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void DeletePlanTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IDeletePlanCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(2);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                });

            var factory = new PlanRequestBuilderFactory(containerMock.Object);
            var request = factory.DeletePlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void CreateBranchTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<ICreatePlanCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.Branch && p.PropertyValue.Equals("BranchTest"));
                });

            var factory = new PlanRequestBuilderFactory(containerMock.Object);
            Should.Throw<ArgumentException>(() => factory.CreateBranch(ProjectKey, PlanKey, "BranchTest/Broken"));

            var request = factory.CreateBranch(ProjectKey, PlanKey, "BranchTest");

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void FavouritePlanTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IFavouritePlanCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.SetFavourite && p.PropertyValue.Equals(true));
                });

            var factory = new PlanRequestBuilderFactory(containerMock.Object);
            var request = factory.FavouritePlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }

        [Test]
        public void UnfavouritePlanTest()
        {
            var containerMock = RequestBuilderFactoryMockBuilder.CreateRequestRegistrationMock<IFavouritePlanCommand>(
                parameters =>
                {
                    parameters.Length.ShouldBe(3);
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.ProjectKey && p.PropertyValue.Equals(ProjectKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.PlanKey && p.PropertyValue.Equals(PlanKey));
                    parameters.ShouldContain(p => p.PropertyName == RequestPropertyNames.SetFavourite && p.PropertyValue.Equals(false));
                });

            var factory = new PlanRequestBuilderFactory(containerMock.Object);
            var request = factory.UnfavouritePlan(ProjectKey, PlanKey);

            request.ShouldNotBeNull();

            containerMock.Verify();
            containerMock.VerifyNoOtherCalls();
        }
    }
}