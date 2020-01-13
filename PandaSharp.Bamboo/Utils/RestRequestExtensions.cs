using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace PandaSharp.Bamboo.Utils
{
    internal static class RestRequestExtensions
    {
        public static void AddParameterIfSet(this IRestRequest restRequest, string parameter, object value)
        {
            if (value != null)
            {
                restRequest.AddParameter(parameter, value);
            }
        }

        public static void AddParameterValues(this IRestRequest restRequest, string parameter, IEnumerable<string> values)
        {
            if (values == null)
            {
                return;
            }

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
