using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Request;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Project.Contract;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Project.Request
{
    internal sealed class DeleteProjectCommand : CommandBase, IDeleteProjectCommand
    {
        [InjectedProperty(RequestPropertyNames.ProjectKey)]
        public string ProjectKey { get; set; }

        public DeleteProjectCommand(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        protected override string GetResourcePath()
        {
            return $"project/{ProjectKey}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.DELETE;
        }
    }
}