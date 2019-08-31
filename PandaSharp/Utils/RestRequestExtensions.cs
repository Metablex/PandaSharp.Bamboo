using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace PandaSharp.Utils
{
    internal static class RestRequestExtensions
    {
        public static void AddParameterIfSet(this IRestRequest restRequest, string parameter, int? value)
        {
            if (value.HasValue)
            {
                restRequest.AddParameter(parameter, value.Value);
            }
        }

        public static void AddParameterValues(this IRestRequest restRequest, string parameter, IEnumerable<string> values)
        {
            var validValues = values
                .Where(value => !string.IsNullOrEmpty(value))
                .ToArray();

            if (validValues.Length > 0)
            {
                var parameterValues = string.Join(",", validValues);
                if (!string.IsNullOrEmpty(parameterValues))
                {
                    restRequest.AddParameter(parameter, parameterValues);
                }
            }
        }
    }
}
