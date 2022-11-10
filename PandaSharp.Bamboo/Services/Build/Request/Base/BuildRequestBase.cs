using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;

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

        protected BuildRequestBase(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverterFactory restResponseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, restResponseConverterFactory)
        {
        }
    }
}