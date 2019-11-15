using PandaSharp.Rest.Contract;
using PandaSharp.Services.Common.Contract;
using PandaSharp.Services.Common.Request;
using PandaSharp.Services.Users.Contract;
using PandaSharp.Services.Users.Response;
using RestSharp;

namespace PandaSharp.Services.Users.Request
{
    internal sealed class CurrentUserRequest : RequestBase<CurrentUserResponse>, ICurrentUserRequest
    {
        public CurrentUserRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
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