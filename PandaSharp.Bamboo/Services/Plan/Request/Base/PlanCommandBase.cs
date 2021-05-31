using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;

namespace PandaSharp.Bamboo.Services.Plan.Request.Base
{
    internal abstract class PlanCommandBase : CommandBase
    {
        [InjectedProperty(RequestPropertyNames.ProjectKey)]
        public string ProjectKey { get; set; }

        [InjectedProperty(RequestPropertyNames.PlanKey)]
        public string PlanKey { get; set; }

        protected PlanCommandBase(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }
    }
}