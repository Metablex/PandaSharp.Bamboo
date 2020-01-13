using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Common.Aspect
{
    internal sealed class ResultCountParameterAspect : RequestParameterAspectBase, IResultCountParameterAspect
    {
        private const string StartIndexParameterName = "start-index";
        private const string MaxResultsParameterName = "max-results";

        public int? StartIndex { get; set; }

        public int? MaxResults { get; set; }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            restRequest.AddParameterIfSet(StartIndexParameterName, StartIndex);
            restRequest.AddParameterIfSet(MaxResultsParameterName, MaxResults);
        }
    }
}