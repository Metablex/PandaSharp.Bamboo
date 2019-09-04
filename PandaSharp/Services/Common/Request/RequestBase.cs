using System;
using System.Collections.Generic;
using System.Linq;
using PandaSharp.Rest.Contract;
using PandaSharp.Services.Common.Contract;
using RestSharp;

namespace PandaSharp.Services.Common.Request
{
    internal abstract class RequestBase<T> : IRestClientProvider, IRequestBase<T>
    {
        private readonly IRestFactory _restFactory;
        private readonly IList<IRequestParameterAspect> _parameterAspects;

        protected RequestBase(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
        {
            _restFactory = restClientFactory;
            _parameterAspects = parameterAspectFactory.GetParameterAspects(GetType());
        }

        protected void ApplyToAspect<TAspect>(Action<TAspect> onUseAspect)
        {
            var aspect = _parameterAspects.OfType<TAspect>().FirstOrDefault();
            if (aspect == null)
            {
                throw new InvalidOperationException($"Aspect of type {typeof(TAspect)} is not supported.");
            }

            onUseAspect(aspect);
        }

        protected abstract string GetResourcePath();

        protected abstract Method GetRequestMethod();

        protected virtual string GetRootElement()
        {
            return null;
        }

        public IRestClient ProvideClient()
        {
            return _restFactory.CreateClient();
        }

        public IRestRequest Build()
        {
            var restRequest = _restFactory.CreateRequest(GetResourcePath(), GetRequestMethod());
            restRequest.RootElement = GetRootElement();

            foreach (var aspect in _parameterAspects)
            {
                aspect.ApplyToRestRequest(restRequest);
            }

            return restRequest;
        }
    }
}
