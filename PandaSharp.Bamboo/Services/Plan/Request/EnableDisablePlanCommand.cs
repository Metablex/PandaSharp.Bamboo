using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Request.Base;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    internal sealed class EnableDisablePlanCommand : PlanCommandBase, IEnableDisablePlanCommand
    {
        [InjectedProperty(RequestPropertyNames.SetEnabled)]
        public bool SetEnabled { get; set; }

        public EnableDisablePlanCommand(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        protected override string GetResourcePath()
        {
            return $"plan/{ProjectKey}-{PlanKey}/enable";
        }

        protected override Method GetRequestMethod()
        {
            return SetEnabled
                ? Method.POST
                : Method.DELETE;
        }
    }
}