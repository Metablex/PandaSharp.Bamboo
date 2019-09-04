using System;
using System.Linq;
using PandaSharp.Utils;
using RestSharp;

namespace PandaSharp.Services.Common.Aspect
{
    internal class ExpandStateParameterAspectBase<T> : RequestParameterAspectBase
        where T : struct, Enum
    {
        private const string ExpandParameterName = "expand";

        public T ExpandState { get; set; }

        public override void ApplyToRestRequest(IRestRequest restRequest)
        {
            var expandStateParameter = Enum
                .GetValues(typeof(T))
                .Cast<T>()
                .Where(p => ExpandState.HasFlag(p))
                .Select(p => p.GetEnumStringRepresentation());

            restRequest.AddParameterValues(ExpandParameterName, expandStateParameter);
        }
    }
}