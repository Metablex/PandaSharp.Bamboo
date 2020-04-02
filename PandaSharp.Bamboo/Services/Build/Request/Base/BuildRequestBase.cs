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
        [InjectedProperty(RequestPropertyNames.ProjectKeyName)]
        public string ProjectKey { get; set; }

        [InjectedProperty(RequestPropertyNames.PlanKeyName)]
        public string PlanKey { get; set; }

        [InjectedProperty(RequestPropertyNames.BuildNumberName)]
        public uint BuildNumber { get; set; }

        protected BuildRequestBase(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }
    }
}