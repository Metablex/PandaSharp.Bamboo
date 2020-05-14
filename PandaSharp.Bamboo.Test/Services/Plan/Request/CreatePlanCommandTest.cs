using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;
using Shouldly;

namespace PandaSharp.Bamboo.Test.Services.Plan.Request
{
    [TestFixture]
    internal sealed class CreatePlanCommandTest : CommandBaseTest<CreatePlanCommand>
    {
        private const string ProjectKey = "ProjectX";
        private const string PlanKey = "MasterPlan";
        private const string BranchKey = "BranchMe";

        protected override IEnumerable<Mock<IRequestParameterAspect>> InitializeParameterAspectMocks()
        {
            yield return CreateParameterAspectMock<ICreatePlanParameterAspect>();
        }

        [Test]
        public async Task ExecuteAsyncTest()
        {
            await CreateCommand().ExecuteAsync();

            VerifyRestRequestCreation($"plan/{ProjectKey}-{PlanKey}/branch/{BranchKey}", Method.PUT);
        }

        [Test]
        public void CreatePlanParameterAspectTest()
        {
            CreateCommand()
                .WithCleanupEnabled(true)
                .WithEnabledState(true)
                .WithVcsBranch("TestBranch");

            VerifyParameterAspectMock<ICreatePlanParameterAspect>(aspect =>
            {
                aspect.IsCleanupEnabled.ShouldBe(true);
                aspect.IsEnabled.ShouldBe(true);
                aspect.VcsBranch.ShouldBe("TestBranch");
            });
        }

        private ICreatePlanCommand CreateCommand()
        {
            var request = CreateRequest();
            request.ProjectKey = ProjectKey;
            request.PlanKey = PlanKey;
            request.BranchName = BranchKey;

            return request;
        }
    }
}