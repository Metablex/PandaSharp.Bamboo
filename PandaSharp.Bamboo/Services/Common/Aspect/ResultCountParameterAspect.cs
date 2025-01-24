using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Common.Aspect
{
    internal sealed class ResultCountParameterAspect : RequestParameterAspectBase, IResultCountParameterAspect
    {
        private int? _startIndex;
        private int? _maxResults;

        public void SetStartIndex(int startIndex)
        {
            _startIndex = startIndex;
        }

        public void SetMaxResults(int maxResults)
        {
            _maxResults = maxResults;
        }

        public override void ApplyToRestRequest(RestRequest restRequest)
        {
            restRequest
                .AddParameterIfSet("start-index", _startIndex)
                .AddParameterIfSet("max-results", _maxResults);
        }
    }
}
