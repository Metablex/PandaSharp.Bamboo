using System;
using System.Collections.Generic;
using System.Linq;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Common.Request
{
    internal abstract class RestCommunicationBase
    {
        private readonly IRestFactory _restFactory;
        private readonly IList<IRequestParameterAspect> _parameterAspects;

        protected RestCommunicationBase(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
        {
            _restFactory = restClientFactory;
            _parameterAspects = parameterAspectFactory.GetParameterAspects(GetType());
        }

        protected TAspect GetAspect<TAspect>()
        {
            var aspect = _parameterAspects.OfType<TAspect>().FirstOrDefault();
            if (aspect == null)
            {
                throw new InvalidOperationException($"Aspect of type {typeof(TAspect)} is not supported.");
            }

            return aspect;
        }

        protected abstract string GetResourcePath();

        protected abstract Method GetRequestMethod();

        protected virtual void ApplyToRestRequest(IRestRequest restRequest)
        {
        }

        protected IRestClient CreateRestClient()
        {
            return _restFactory.CreateClient();
        }

        protected IRestRequest BuildRequest()
        {
            var restRequest = _restFactory.CreateRequest(GetResourcePath(), GetRequestMethod());

            ApplyToRestRequest(restRequest);
            foreach (var aspect in _parameterAspects)
            {
                aspect.ApplyToRestRequest(restRequest);
            }

            return restRequest;
        }
    }
}