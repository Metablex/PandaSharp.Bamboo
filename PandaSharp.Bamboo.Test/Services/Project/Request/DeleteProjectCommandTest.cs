using System.Threading.Tasks;
using NUnit.Framework;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Bamboo.Services.Project.Request;
using PandaSharp.Bamboo.Test.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Test.Services.Project.Request
{
    [TestFixture]
    internal sealed class DeleteProjectCommandTest : CommandBaseTest<DeleteProjectCommand>
    {
        private const string ProjectKey = "ProjectX";

        [Test]
        public async Task ExecuteAsyncTest()
        {
            await CreateCommand()
                .ExecuteAsync();

            VerifyRestRequestCreation($"project/{ProjectKey}", Method.DELETE);
        }

        private IDeleteProjectCommand CreateCommand()
        {
            var request = CreateRequest();
            request.ProjectKey = ProjectKey;

            return request;
        }
    }
}