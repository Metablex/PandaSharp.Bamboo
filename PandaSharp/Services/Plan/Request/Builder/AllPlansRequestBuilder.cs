using PandaSharp.Rest.Contract;
using PandaSharp.Services.Common;
using PandaSharp.Services.Plan.Response;
using PandaSharp.Utils;
using RestSharp;

namespace PandaSharp.Services.Plan.Request.Builder
{
    internal class AllPlansRequestBuilder : RequestBase<AllPlansResponse>, IAllPlansRequestBuilder
    {
        private int? _startIndex;
        private int? _maxResults;
        private PlanExpandState _planExpandState;

        public AllPlansRequestBuilder(IRestFactory restClientFactory) 
            : base(restClientFactory)
        {
            _planExpandState = PlanExpandState.OnlyPlans;
        }

        public IAllPlansRequestBuilder IncludeDetailsAndActions()
        {
            _planExpandState = PlanExpandState.IncludingDetailsAndActions;
            return this;
        }

        public IAllPlansRequestBuilder IncludeDetails()
        {
            _planExpandState = PlanExpandState.IncludingDetails;
            return this;
        }

        public IAllPlansRequestBuilder StartAtIndex(int startIndex)
        {
            _startIndex = startIndex;
            return this;
        }

        public IAllPlansRequestBuilder WithMaxResult(int maxResult)
        {
            _maxResults = maxResult;
            return this;
        }

        public override IRestRequest Build()
        {
            var restRequest = CreateEmptyRequest("plan", Method.GET);
            restRequest.AddParameterIfSet(ParameterConstants.StartIndex, _startIndex);
            restRequest.AddParameterIfSet(ParameterConstants.MaxResults, _maxResults);
            restRequest.AddParameterEnum(ParameterConstants.Expand, _planExpandState);

            return restRequest;
        }
    }
}
