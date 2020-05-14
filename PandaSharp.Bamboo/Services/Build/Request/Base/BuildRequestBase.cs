using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Request;
using PandaSharp.Bamboo.Services.Common.Types;

namespace PandaSharp.Bamboo.Services.Build.Request.Base
{
    internal abstract class BuildRequestBase<T> : RequestBase<T>
        where T : class, new()
    {
        [InjectedProperty(RequestPropertyNames.ProjectKey)]
        public string ProjectKey { get; set; }

        [InjectedProperty(RequestPropertyNames.PlanKey)]
        public string PlanKey { get; set; }

        [InjectedProperty(RequestPropertyNames.BuildNumber)]
        public uint BuildNumber { get; set; }

        protected BuildRequestBase(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }
    }
}