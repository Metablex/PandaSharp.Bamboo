using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class CreatePlanCommandTest
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const string BranchKey = "BranchMe";

        [Test]
        public void UnauthorizedExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock(HttpStatusCode.Unauthorized);

            var request = RequestTestMockBuilder.CreateCommand<CreatePlanCommand>(restFactoryMock);

            Should.ThrowAsync<UnauthorizedAccessException>(() => request.ExecuteAsync());
        }

        [Test]
        public void AnyErrorWhileExecuteTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock(HttpStatusCode.NotFound);

            var request = RequestTestMockBuilder.CreateCommand<CreatePlanCommand>(restFactoryMock);

            Should.ThrowAsync<InvalidOperationException>(() => request.ExecuteAsync());
        }

        [Test]
        public async Task CreatePlanParameterAspectTest()
        {
            var restFactoryMock = RequestTestMockBuilder.CreateRestFactoryMock();
            var aspect = RequestTestMockBuilder.CreateParameterAspectMock<ICreatePlanParameterAspect>();

            var command = RequestTestMockBuilder.CreateCommand<CreatePlanCommand>(restFactoryMock, aspect);
            command.ProjectKey = ProjectKey;
            command.PlanKey = PlanKey;
            command.BranchName = BranchKey;

            command
                .WithCleanupEnabled(true)
                .WithEnabledState(true)
                .WithVcsBranch("TestBranch");

            await command.ExecuteAsync();

            restFactoryMock.Verify(r => r.CreateRequest($"plan/{ProjectKey}-{PlanKey}/branch/{BranchKey}", Method.Put), Times.Once);

            aspect.Verify(i => i.SetIsCleanupEnabledFilter(true), Times.Once);
            aspect.Verify(i => i.SetIsEnabledFilter(true), Times.Once);
            aspect.Verify(i => i.SetVcsBranchFilter("TestBranch"), Times.Once);
        }
    }
}
