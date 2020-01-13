using System;
using System.Linq;
using PandaSharp.Bamboo.Utils;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Common.Aspect
{
    internal sealed class ExpandStateParameterAspect<T> : RequestParameterAspectBase, IExpandStateParameterAspect<T>
        where T : struct, Enum
    {
        private const string ExpandParameterName = "expand";

        private T? _expandState;

        public void AddExpandState(T state)
        {
            _expandState.AddEnumMember(state);
        }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            if (!_expandState.HasValue)
            {
                return;
            }

            var expandStateParameter = Enum
                .GetValues(typeof(T))
                .Cast<T>()
                .Where(p => _expandState.Value.HasFlag(p))
                .Select(p => p.GetEnumStringRepresentation());

            restRequest.AddParameterValues(ExpandParameterName, expandStateParameter);
        }
    }
}