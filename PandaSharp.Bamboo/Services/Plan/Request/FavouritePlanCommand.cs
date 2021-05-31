using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Request.Base;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
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