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

        protected abstract string ResourcePath { get; }

        protected abstract string RootElement { get; }

        protected abstract Method RequestMethod { get; }

        public RequestBase(IRestFactory restClientFactory, IList<IRequestParameterAspect> parameterAspects)
        {
            _restFactory = restClientFactory;
            _parameterAspects = parameterAspects;
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

        public IRestClient ProvideClient()
        {
            return _restFactory.CreateClient();
        }

        public IRestRequest Build()
        {
            var restRequest = _restFactory.CreateRequest(ResourcePath, RequestMethod);
            restRequest.RootElement = RootElement;

            foreach (var aspect in _parameterAspects)
            {
                aspect.ApplyToRestRequest(restRequest);
            }

            return restRequest;
        }
    }
}
