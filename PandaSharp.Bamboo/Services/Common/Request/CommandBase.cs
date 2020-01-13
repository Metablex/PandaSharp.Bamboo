using System;
using System.Net;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Utils;

namespace PandaSharp.Bamboo.Services.Common.Request
{
    internal abstract class CommandBase : RestCommunicationBase, ICommandBase
    {
        protected CommandBase(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public void Execute()
        {
            var client = CreateRestClient();
            var request = BuildRequest();
            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Unable to authenticate. Please check your credentials.");
                }

                throw new InvalidOperationException($"Error retrieving response: {response.GetErrorResponseMessage()}");
            }
        }
    }
}