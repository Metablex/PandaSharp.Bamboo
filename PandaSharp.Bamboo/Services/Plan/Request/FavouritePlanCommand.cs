using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Request.Base;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Plan.Request
{
    internal sealed class FavouritePlanCommand : PlanCommandBase, IFavouritePlanCommand
    {
        [InjectedProperty(RequestPropertyNames.SetFavourite)]
        public bool SetFavourite { get; set; }

        public FavouritePlanCommand(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        protected override string GetResourcePath()
        {
            return $"plan/{ProjectKey}-{PlanKey}/favourite";
        }

        protected override Method GetRequestMethod()
        {
            return SetFavourite
                ? Method.POST
                : Method.DELETE;
        }
    }
}