using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using PandaSharp.Rest.Contract;
using PandaSharp.Services.Common.Contract;
using PandaSharp.Utils;
using RestSharp;

namespace PandaSharp.Services.Common.Request
{
    internal abstract class RequestBase<T> : IRequestBase<T>
        where T : class, new()
    {
        private readonly IRestFactory _restFactory;
        private readonly IList<IRequestParameterAspect> _parameterAspects;

        protected RequestBase(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
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

        public T Execute()
        {
            var client = _restFactory.CreateClient();
            var request = BuildRequest();
            var response = client.Execute<T>(request);

            if (!response.IsSuccessful)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Unable to authenticate. Please check your credentials.");
                }

                throw new InvalidOperationException($"Error retrieving response: {response.GetErrorResponseMessage()}");
            }

            return response.Data;
        }

        private IRestRequest BuildRequest()
        {
            var restRequest = _restFactory.CreateRequest(GetResourcePath(), GetRequestMethod());

            foreach (var aspect in _parameterAspects)
            {
                aspect.ApplyToRestRequest(restRequest);
            }

            return restRequest;
        }
    }
}
