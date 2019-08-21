using PandaSharp.Rest.Contract;
using PandaSharp.Services.Common;
using PandaSharp.Services.Plan.Contract;
using PandaSharp.Utils;
using RestSharp;

namespace PandaSharp.Services.Plan.Model
{
    internal class AllPlansRequest : RequestBase, IAllPlansRequest
    {
        private int? _startIndex;
        private int? _maxResults;
        private PlanExpandState _planExpandState;

        public AllPlansRequest(IRestFactory restClientFactory) 
            : base(restClientFactory)
        {
            _planExpandState = PlanExpandState.OnlyPlans;
        }

        public IAllPlansRequest IncludeDetailsAndActions()
        {
            _planExpandState = PlanExpandState.IncludingDetailsAndActions;
            return this;
        }

        public IAllPlansRequest IncludeDetails()
        {
            _planExpandState = PlanExpandState.IncludingDetails;
            return this;
        }

        public IAllPlansRequest StartAtIndex(int startIndex)
        {
            _startIndex = startIndex;
            return this;
        }

        public IAllPlansRequest WithMaxResult(int maxResult)
        {
            _maxResults = maxResult;
            return this;
        }

        public IAllPlansResponse Execute()
        {
            var restRequest = CreateEmptyRequest("plan", Method.GET);
            restRequest.AddParameterIfSet(ParameterConstants.StartIndex, _startIndex);
            restRequest.AddParameterIfSet(ParameterConstants.MaxResults, _maxResults);
            restRequest.AddParameterEnum(ParameterConstants.Expand, _planExpandState);

            return Execute<AllPlansResponse>(restRequest);
        }
    }
}
