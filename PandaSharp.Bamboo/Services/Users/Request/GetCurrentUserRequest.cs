using PandaSharp.Bamboo.Services.Users.Contract;
using PandaSharp.Bamboo.Services.Users.Response;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Users.Request
{
    internal sealed class GetCurrentUserRequest : RequestBase<CurrentUserResponse>, IGetCurrentUserRequest
    {
        public GetCurrentUserRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverterFactory restResponseConverterFactory)
            : base(restClientFactory, parameterAspectFactory, restResponseConverterFactory)
        {
        }

        protected override string GetResourcePath()
        {
            return "currentUser";
        }

        protected override Method GetRequestMethod()
        {
            return Method.Get;
        }
    }
}
