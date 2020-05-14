using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Request;
using PandaSharp.Bamboo.Services.Users.Contract;
using PandaSharp.Bamboo.Services.Users.Response;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Users.Request
{
    internal sealed class GetCurrentUserRequest : RequestBase<CurrentUserResponse>, IGetCurrentUserRequest
    {
        public GetCurrentUserRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        protected override string GetResourcePath()
        {
            return "currentUser";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}