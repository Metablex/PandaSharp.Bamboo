using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Request;
using PandaSharp.Bamboo.Services.Common.Types;

namespace PandaSharp.Bamboo.Services.Plan.Request.Base
{
    internal abstract class PlanRequestBase<T> : RequestBase<T>
        where T : class, new()
    {
        [InjectedProperty(RequestPropertyNames.ProjectKey)]
        public string ProjectKey { get; set; }

        [InjectedProperty(RequestPropertyNames.PlanKey)]
        public string PlanKey { get; set; }

        protected PlanRequestBase(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }
    }
}