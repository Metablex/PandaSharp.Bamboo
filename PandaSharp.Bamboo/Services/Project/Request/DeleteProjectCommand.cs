using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Contract;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Project.Request
{
    internal sealed class DeleteProjectCommand : CommandBase, IDeleteProjectCommand
    {
        private readonly IRestCommunicationContext _communicationContext;

        public DeleteProjectCommand(
            IRestCommunicationContext communicationContext,
            IRestFactory restClientFactory,
            IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
            _communicationContext = communicationContext;
        }

        protected override string GetResourcePath()
        {
            var projectKey = _communicationContext.GetContextParameter<string>(RequestPropertyNames.ProjectKey);

            return $"project/{projectKey}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Delete;
        }
    }
}
