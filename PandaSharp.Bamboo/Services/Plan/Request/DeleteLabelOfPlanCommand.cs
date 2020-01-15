using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Request.Base;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    internal sealed class DeleteLabelOfPlanCommand : PlanCommandBase, IDeleteLabelOfPlanCommand
    {
        [InjectedProperty(RequestPropertyNames.LabelName)]
        public string LabelName { get; set; }

        public DeleteLabelOfPlanCommand(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        protected override string GetResourcePath()
        {
            return $"plan/{ProjectKey}-{PlanKey}/label/{LabelName}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.DELETE;
        }
    }
}