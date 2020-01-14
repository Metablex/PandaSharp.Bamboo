using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Request;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Contract;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    internal sealed class DeletePlanCommand : CommandBase, IDeletePlanCommand
    {
        [InjectedProperty(RequestPropertyNames.ProjectKeyName)]
        public string ProjectKey { get; set; }

        [InjectedProperty(RequestPropertyNames.PlanKeyName)]
        public string PlanKey { get; set; }

        public DeletePlanCommand(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        protected override string GetResourcePath()
        {
            return $"plan/{ProjectKey}-{PlanKey}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.DELETE;
        }
    }
}